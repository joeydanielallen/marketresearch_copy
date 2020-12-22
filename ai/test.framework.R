

tests <- setRefClass(
  Class = 'tests',
  fields = list(
    'tests' = "list"
  ),
  methods = list(
    'add_category' = function(x) {
      tests[[length(tests)+1]] <<- list()
      names(tests)[length(tests)] <<- x
    },
    'list_categories' = function() {
      names(tests)
    },
    'add_test' = function(x, y, z) {
      if( class(x) != 'function') stop('first input must be a function')
      if( ! (y %in% names(tests)) ) stop('second input must match a category name in list')
      tests[[y]][[ length(tests[[y]]) + 1]] <<- x
      names(tests[[y]])[length(tests[[y]])] <<- z
    },
    'list_tests' = function() {
      tmp <- lapply(X = tests, FUN = function(x) names(x))
      names(tmp) <- names(tests)
      return(tmp)
    },
    'run_tests' = function() {
      for(i in 1:length(tests)) {
        print(paste('Test Category:',names(tests)[i], '--------'))
        for(j in 1:length(tests[[i]])) {
          tmp <- tests[[i]][[j]]()
          print(paste(' ',names(tests[[i]])[j], '.....', ifelse(tmp, 'PASS','FAIL') ) ) 
        }
      }
    }
  )
)