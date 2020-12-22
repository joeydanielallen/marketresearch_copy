
criteria_check <- function(x) {
  return(T)
}

norm_entries <- function(criterion, data, fill = 0) {
  raw_entries <- data[[criterion]]
  raw_entries[is.na(raw_entries)] <- fill
  total <- sum(raw_entries)
  if(total == 0) total <- 1
  return(raw_entries / total)
}

handle_fixed_position <- function(entry_ids, entries, fixed) {
  fixed_entries <- list()
  fixed_entry_ids <- c()
  not_fixed_entries <- entries
  not_fixed_entry_ids <- entry_ids
  if( length(fixed) > 0){
    to_fix <- which(entry_ids %in% names(fixed))
    fixed_entries <- lapply(X = entries, FUN = function(x) x[to_fix])
    fixed_entry_ids <- entry_ids[to_fix]
    not_fixed_entries <- lapply(X = entries, FUN = function(x) x[-to_fix])
    not_fixed_entry_ids <- entry_ids[-to_fix]
  }
  return(list(
    'fixed' = list(
      'ids' = fixed_entry_ids,
      'entries' = fixed_entries
    ),
    'not_fixed' = list(
      'entries' = not_fixed_entries,
      'ids' = not_fixed_entry_ids
    )
  ))
}

rank <- function(entries, criteria, weights) {
  
  # normalize features
  normed_features <- lapply(X = criteria, FUN = function(criterion){
    norm_entries(criterion, entries)
  })
  n <- matrix(unlist(normed_features), nrow = length(entries[[1]]), ncol = length(normed_features)) 

  # calculate score
  w <- matrix(weights[[length(criteria)]], ncol = 1, nrow = length(criteria))
  scores <- n %*% w
  
  return(scores)
}

# expect fixed to be a named vector with label equal to entry_id and value equal to position
ahp <- function(entry_ids, entries, criteria, fixed = c()){
  if(criteria_check(criteria)) {
    weights <- list(
      c(1),
      c(2/3, 1/3),
      c(0.5396146, 0.2969613, 0.1634241),
      c(0.46729598, 0.27718059, 0.16008848, 0.09543495),
      c(0.41853929, 0.26251761, 0.15992286, 0.09725359, 0.06176665),
      c(0.38249747, 0.25040175, 0.15958026, 0.10063029, 0.06407740, 0.04281282),
      c(0.35428431, 0.23992753, 0.15865497, 0.10362467, 0.06756458, 0.04476931, 0.03117461)
    )
    
    # validation of inputs ---------------------------
    if(length(criteria) == 0) stop('must have at least one criterion')
    if(length(criteria) > length(weights)) stop('current algorithm can not handle this many criteria')
    if( !all(criteria %in% names(entries)) ) stop('some criteria not defined in entries')
    
    # handle entries to be fixed ----------------------
    fixed_or_not <- handle_fixed_position(entry_ids, entries, fixed)
    to_rank <- fixed_or_not$not_fixed
    
    # rank -----------------------------
    if( length(to_rank$ids) > 0 ){
      # dont sequence items are put in the bottom
      entries_to_sequence <- list()
      ids_to_sequence <- c()
      dont_sequence<- c()
      # for now, assume all need to be sequenced
      entries_to_sequence <- to_rank$entries
      ids_to_sequence <- to_rank$ids
      # print(entries_to_sequence)
      scores <- rank(entries_to_sequence, criteria, weights)
    } else {
      scores <- c()
      dont_sequence <- c()
    }

    all_scores <- c(scores, rep(NA, length(dont_sequence)))
    all_ids <- c(ids_to_sequence, dont_sequence)
    
    # form results ----------------------
    # for initial results with unfixed entries
    if( length(all_ids) > 0){
      idx <- order(all_scores, decreasing = T, na.last = T)
      ranked_scores <- all_scores[idx]
      ranked_ids <- all_ids[idx]
    } else {
      ranked_scores <- c()
      ranked_ids <- c()
    }
    # put back in fixed entries in proper position
    if( length(fixed_or_not$fixed$ids) > 0){ # this will break if 
      sorted_fixed <- sort(fixed)
      for(i in 1:length(sorted_fixed)) {
        idx <- sorted_fixed[i]
        id <- names(sorted_fixed)[i]
        if(idx > length(ranked_scores)) {
          ranked_scores <- c(ranked_scores, NA)
          ranked_ids <- c(ranked_ids, id)
        }else{
          ranked_scores <- c(ranked_scores[0:(idx-1)], NA, ranked_scores[idx:length(ranked_scores)])
          ranked_ids <- c(ranked_ids[0:(idx-1)], id, ranked_ids[idx:length(ranked_ids)])
        }
      }
    }
    
    results <- list(
      'scores' = ranked_scores,
      'ids_in_order'= ranked_ids
    )
    return(results)
    
  } else {
    stop('criteria are malformed')
  }
}


 
