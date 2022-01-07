/*      SweetnSalty Interactive
    DUE 1/7/22 @10PM

SAME STUFF
- The file will be contained in a directory called SweetnSaltyJsInteractive   
- As always, when the number is a multiple of three, print “sweet” instead of the number
- If the number is a multiple of five, print “salty” instead of the number. 
- For numbers which are multiples of three and five, print “sweet’nSalty” instead of the number. 

NEW STUFF
- The difference is that you will use the JS to manipulate the DOM and print the numbers and words to the web page (NOT the console) 
- This will be a single page application that takes the user through the following steps by displaying 
and not displaying text and these instructions. Each line will be displayed one at a time.  
-- “Please enter a starting number” 
-- “Please enter a final number” 
-- “Please press enter” 
- You will start with the template html and only add, delete, and alter elements with javaScript DOM manipulation 
as the user moves through the steps.  
- You must display each step separately one at a time, while not displaying the other steps.  
- You must have styling using internal (not inline) styling.  
- The start and stop numbers must be validated to be at least 200 apart and no more than 10,000 apart. 
- There will be 40 numbers on each line, except the last line. 
- The numbers printed to the web page will be formatted correctly (with commas like => 12,453) 
- Every “sweet”, “salty”, and “sweetnsalty” printed must have a green background with white text.  
- You also will implement input validation to verify that only positive numbers are entered and that the start number is less than the stop number. 
- You will have small, red text that pops up under the input box to explain what the user did wrong while presenting that step again.   
**Game progression: **
- Start with a screen that explains the game and how the user will input their choices.   
- Each step is visible only after the previous step has been successfully completed. 
- Present a start button.  
-- Step 1: The user enters the number to start with. Then clicks Enter.  
-- Step 2: The user enters the number to finish with. Then clicks Enter.  
-- Step 3: Print sweet, salty, sweet'nSalty, and the numbers to the screen as the user instructed.  
-- Step 4: Print the total number of sweet, salty, and sweet’nSalty after printing the numbers and words. 
-- Step 0: After all the numbers have been printed, present a button allowing the user to delete everything and restart.
*/




 /*
let text1 = document.createElement('h4')
document.body.appendChild(text1)
text1.innerText = `Please enter a starting number`

let form = document.createElement("form")

form.setAttribute("id", "myForm");
document.body.appendChild(form);    

var y = document.createElement('input');
y.setAttribute("type", "text");
y.setAttribute("placeholder", "starting number here");
y.setAttribute("id", "input")
document.getElementById("myForm").appendChild(y);

let numb = document.getElementById('input').value

console.log(numb)
*/




/*
// create the title element for the list
let title = document.createElement('h1');
//add the element to the body
document.body.appendChild(title);
//text to be displayed
title.innerText = `Sweet 'n Salty Interactive`;

//create text element for user promt
let startText = document.createElement('h4');
//add the element to the body
document.body.appendChild(startText)
//text to be displayed
startText.innerText = `Please enter a starting number:`

// create the input element
let startInput = document.createElement('input');
//add the element to the body
document.body.appendChild(startInput);

//create text element for user promt
let endText = document.createElement('h4');
//add the element to the body
document.body.appendChild(endText)
//text to be displayed
endText.innerText = `Please enter a final number:`

// create the input element
let endInput = document.createElement('input');
//add the element to the body
document.body.appendChild(endInput);


//instantiating and getting userinput of startNumb
const userStartInput =  document.querySelector("startInput")
//let userStartInput = document.getElementById("startNumb");

//instantiating array to hole inputs
let db = []
//create user input id as startNumb
startInput.innerHTML = `<input id="startNumb" value="THIS IS WHERE YOU INPUT"></input>`

let test = document.getElementById('startNumb').value;
console.log(test)

startInput.addEventListener('keypress', (e) => {
    if (e.key == 'Enter') {
        console.log(userStartInput)  
        //db.push(userStartInput)
    }
});

console.log(db);
*/