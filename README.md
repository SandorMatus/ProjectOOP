# ProjectOOP
Tu sa progamuje bohovsky kod
- Matúš Šándor
- Adrián Laban

# Theme : text adventure with simple WPF GUI
- game/story is created by correctly formatting the saveGame.txt, the game recognizes 3 types of questions :
1. Questions with string as an a answer (these questions only recieve string)
2. Multiple questions input (question is chosen randomly)
3. Questions with integer input (insert range from high to low and user is prommpted to guess it)

- Every first question after answer (except the first) starts with ; more questions are followed up with ~ on new line
- Every question needs to be ended with {
- Answers are divided by ~ and ended by }<expected string/number>}<condition number>
  Condition numbers are : 1-NEXT LINE, 2-WIN, 3-LOSE, 4-REPEAT
- Questions and answers create a block starting and ending with ;
- Last block is for LOSE screen and 2nd last is for WIN screen (these are only stated once)
- Illegal characters to use in sentences are : ~ and ; and } and {
