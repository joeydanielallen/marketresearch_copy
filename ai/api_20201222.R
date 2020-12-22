

library(httr)
library(jsonlite)
library(data.table)
library(plumber)

ahp <- new.env()
source('ahp.R', local = ahp)

get_data <- function(fsg) {
  # call data from API
  qry_endpoint <- '' # put endpoint url here. include /
  res <- GET(url = paste0(qry_endpoint,fsg)) 
  body <- fromJSON(content(res))
  
  # parse data
  dt <- data.table(matrix(unlist(
    strsplit(x = body$psc, split = "*", fixed = T) ), nrow = length(body$psc), ncol = 10, byrow = T))
  setnames(dt, c('psc_lookup','duns','duns_number','name','cage', 'total', 'dod', 'af', 'naics_dollars', 'psc_dollars'))
  for(i in c(3,6:10)){
    dt[[i]] <- as.numeric(dt[[i]])
  }

  return(dt)  
}

pick_option <- function(x) {
  y <- x
  idx <- grep(pattern = ';', x = x, fixed = T)
  for(i in idx){
    tmp <- strsplit(x[i], split = ';', fixed = T)[[1]]
    y[i] <- ''
    for(j in tmp){
      if(j != '' | j != ' '){
        y[i] <- j
        break
      }
    }
  }
  return(y)
}

check_nsn <- function(nsn) {
  response <- 'ok'
  
  # must be all numbers
  if(is.na(as.numeric(nsn))) {
    response <- 'NSN input must be numeric value'
  } else {
    # must be 13 digits
    if( as.numeric(nsn) >= 1E13 | as.numeric(nsn) < 1E12) {
      response <- 'NSN must be 13 digits'
    }
  }
  
  return(response)
}

pr <- plumber$new()

# health checkpoint
pr$handle('GET','/', function(req, res){
  "ok"
}, serializer = serializer_unboxed_json())

pr$handle('GET','/nsn/<nsn>', function(nsn, req, res){
  meta = list('times' = list())
  valid <- check_nsn(nsn)
  if (valid == 'ok') {
    # get data
    rank_input <- get_data(substr(nsn,1,4))
    # deal with multiple names and cages
    rank_input$name <- pick_option(rank_input$name)
    rank_input$cage <- pick_option(rank_input$cage)
    # rank data
    data_list <- list(
      'total' = rank_input$total,
      'dod' = rank_input$dod,
      'af' = rank_input$af,
      'naics' = rank_input$naics_dollars,
      'psc' = rank_input$psc_dollars
    )
    ranks <- ahp$ahp(rank_input$duns, data_list, c('psc','naics','af','dod','total'))
    # form response
    info <- rank_input[data.table('duns'= ranks$ids_in_order),.(duns,name, cage), on = 'duns']
    response <- lapply(X = 1:length(ranks$scores), 
                       FUN = function(x) list(
                         'id' = ranks$ids_in_order[x],
                         'duns' = info$duns[x],
                         'cage' = info$cage[x],
                         'name' = info$name[x],
                         'score' = ranks$scores[x]))
    res$status <- 200
    if(length(response) > 1000) {
      ret <- response[1:1000]
    } else {
      ret <- response
    }
    return(list('results' = ret))
  } else {
    res$status <- 400
    return(list('error' = valid))
  }
}, serializer = serializer_unboxed_json())

pr$run(host = '0.0.0.0', port = 8989)
# pr$run(port = 8989) # run outside of container





