

source('test.framework.R')

code <- new.env()
source('ahp.R',local = code)


ahp_tests <- tests$new()

# check norm entries
ahp_tests$add_category('normalization')
ahp_tests$add_test(function(){
  input <- list('a' = c(1L,2L,3L,4L))
  output <- code$norm_entries('a', input)
  all(output == c(0.1, 0.2, 0.3, 0.4))
}, 'normalization', 'check integer input normalization')
ahp_tests$add_test(function(){
  input <- list('a' = c(5.5,1.2,1.3,2.0))
  output <- code$norm_entries('a', input)
  all(output == c(0.55, 0.12, 0.13, 0.2))
}, 'normalization', 'check float input normalization')
ahp_tests$add_test(function(){ 
  input <- list('a' = c(-1, 1, -2, 2))
  output <- code$norm_entries('a', input)
  all(output == c(-1, 1, -2, 2))
}, 'normalization', 'check 0 total')
ahp_tests$add_test(function(){ 
  input <- list('a' = c(2, NA, NA, 2))
  output <- code$norm_entries('a', input)
  all(output == c(0.5, 0, 0, 0.5))
}, 'normalization', 'check default fill')
ahp_tests$add_test(function(){ 
  input <- list('a' = c(2, NA, NA, 2))
  output <- code$norm_entries('a', input, 0.5)
  all(output == c(0.4, 0.1, 0.1, 0.4))
}, 'normalization', 'check input fill')

# check rank calculation
ahp_tests$add_category('rank calculation')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,2,6))
  output <- code$rank(input, c('a'), list(c(1)))
  all(output == matrix(c(0.2, 0.2, 0.6),nrow = 3, ncol = 1) )
},'rank calculation', 'one criteria')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,2,6), 'b' = c(6,2,2))
  output <- code$rank(input, c('a', 'b'), list(c(1), c(1,0)))
  all(output == matrix(c(0.2, 0.2, 0.6),nrow = 3, ncol = 1) )
},'rank calculation', 'two criteria - set 1')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,2,6, 6, 2, 2), 'b' = c(6,2,2, 3, 3, 4))
  output <- code$rank(input, c('a', 'b'), list(c(1), c(10,1)))
  all(output == matrix(c(1.30, 1.10,3.10, 3.15, 1.15, 1.20),nrow = 6, ncol = 1) )
},'rank calculation', 'two criteria - set 2')

# check eigenvalues
ahp_tests$add_category('eigenvalues')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,2,6))
  output <- code$ahp(1:3, input, c('a'))
  all(output$scores == sort(c(0.2, 0.2, 0.6),decreasing = T ) )
},'eigenvalues', 'one criteria')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,1,1), 'b' = c(1,2,1))
  output <- code$ahp(1:3, input, c('a','b'))
  all(round(output$scores,7) == round(sort(c(5/12, 1/3, 1/4),decreasing = T ),7) )
},'eigenvalues', 'two criteria')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,1,1), 'b' = c(1,2,1), 'c' = c(1,1,1))
  output <- code$ahp(1:3, input, c('a','b','c'))
  all(round(output$scores,7) == round(sort(c(0.3985223, 0.3378590, 0.2636187),decreasing = T ),7) )
},'eigenvalues', 'three criteria')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,1,1), 'b' = c(1,2,1), 'c' = c(1,1,1), 'd' = c(2,2,1))
  output <- code$ahp(1:3, input, c('a','b','c','d'))
  all(round(output$scores,7) == round(sort(c(0.3944799, 0.3469511, 0.2585690),decreasing = T ),7) )
},'eigenvalues', 'four criteria')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,1,1), 'b' = c(1,2,1), 'c' = c(1,1,1), 'd' = c(2,2,1), 'e' = c(5,1,1))
  output <- code$ahp(1:3, input, c('a','b','c','d','e'))
  all(round(output$scores,7) == round(sort(c(0.4112271, 0.3369265, 0.2518464),decreasing = T ),7) )
},'eigenvalues', 'five criteria')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,1,1), 'b' = c(1,2,1), 'c' = c(1,1,1), 'd' = c(2,2,1), 'e' = c(5,1,1),'f' = c(1,0,10))
  output <- code$ahp(1:3, input, c('a','b','c','d','e','f'))
  all(round(output$scores,7) == round(sort(c(0.3969564, 0.3234247, 0.2796189),decreasing = T ),7) )
},'eigenvalues', 'six criteria')
ahp_tests$add_test(function(){
  input <- list('a' = c(2,1,1), 'b' = c(1,2,1), 'c' = c(1,1,1), 'd' = c(2,2,1), 'e' = c(5,1,1),'f' = c(1,0,10), 'g' = c(1,1,2))
  output <- code$ahp(1:3, input, c('a','b','c','d','e','f','g'))
  all(round(output$scores,7) == round(sort(c(0.3915829, 0.3203154, 0.2881016),decreasing = T ),7) )
},'eigenvalues', 'seven criteria')


ahp_tests$run_tests()


