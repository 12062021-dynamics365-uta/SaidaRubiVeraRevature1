/*
        Sweet n Salty
    DUE: 1/5/22 @ 10PM
- Print the numbers 1 to 1000 to the console.
- Print them in groups of 20 per line with one space separating each number. 
    This will require string concatenation to print the 20-number strings to the console at a time. 
- When the number is a multiple of three, print “sweet” instead of the number on the console.
- If the number is a multiple of five, print “salty” (instead of the number) to the console.
- For numbers which are multiples of three and five, print “sweet’nSalty” to the console (instead of the number).
- After the numbers have all been printed, print out how many "sweet"'s, 
    how many "salty"’s, and how many "sweet’nSalty"’s. 
    These are three separate groups, so sweet’nSalty does not increment sweet or salty (and vice versa).
- Include verbose commentary in the source code to tell me what each few lines are doing.
*/


// Instantiate counters for each word and loop conditions
let snsCounter = 0
let swCounter = 0
let saCounter = 0
let counter = 1
let output = ""

//Loop through numbers 1 through 1000
while (counter <= 1000) 
{

  //print 20 numbers per line
    for (let i = 0; i < 20; i++) 
    {
        if (counter%5 == 0 && counter%3 == 0) //If number is divisable by 3 and 5
        {
            output += "SweetnSalty"; //print this
            snsCounter++; //and count each time sweetnsalty is printed
        }
        else if (counter%5 == 0) //If number is divisable by 5
        {
            output += "Salty "; //print this
            saCounter++; //and count each time salty is printed
        
        }
        else if (counter%3 == 0) //If number is divisiable by 3
        {
            output += "Sweet "; //print this
            swCounter++; //and count each time sweet is printed
        }
        else {
            output += counter + " "; //if not divisible by 3, 5, or both print the number and the other part of the string
        }       
        counter++;

    }

    console.log(output); //print the string

    console.log(' ');   
}

console.log(`# of Sweet: ${swCounter}`) //print the amount of times the word sweet was printed
console.log(`# of Salty: ${saCounter}`) //print the amount of times the word saly was printed
console.log(`# of SweetnSalty: ${snsCounter}`) //print the amount of times the word sweetnsalty was printed
