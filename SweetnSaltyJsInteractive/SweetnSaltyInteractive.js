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


// create the title element for the list
let title = document.createElement('h1');
//add the element to the body
document.body.appendChild(title);
//text to be displayed
title.innerText = `Sweet 'n Salty Interactive`;


// create the input element
let startInput = document.createElement('input');
//create text element for user promt
let startText = document.createElement('h4');
//create text element for user promt
let endText = document.createElement('h4');
// create the input element
let endInput = document.createElement('input');
//creating start game button
let startButton = document.createElement('button')
//text in game
startButton.innerText = 'Start Game!'
//Show start button
document.body.appendChild(startButton)
//creating strat number button
let startNumbButton = document.createElement('button');
//text in button
startNumbButton.innerText = 'Submit'
//ceating end number button
let endNumbButton = document.createElement('button');
//text in button
endNumbButton.innerText = 'Submit'
//creating start game button
let endButton = document.createElement('button')


let startNumb = 0
let endNumb = 0


startButton.addEventListener('click', (e) => {
    document.body.innerHTML = ""
    //add the element to the body
    document.body.appendChild(startText)
    //text to be displayed
    startText.innerText = `Please enter a starting number:`
    //add the element to the body
    document.body.appendChild(startInput);
    startInput.focus();
    // show button
    document.body.appendChild(startNumbButton);
})


startInput.addEventListener('keypress', (e) => {
    if (e.key == 'Enter') {
        startNumb = startInput.value
        console.log(startNumb)  
        document.body.innerHTML = ""
        //add the element to the body
        document.body.appendChild(endText)
        //text to be displayed
        endText.innerText = `Please enter a final number:`
        //add the element to the body
        document.body.appendChild(endInput);
        endInput.focus();
        //show button
        document.body.appendChild(endNumbButton);
    }
});

startNumbButton.addEventListener('click', (e)=> {
    startNumb = startInput.value
    console.log(startNumb)
    document.body.innerHTML = ""
    //add the element to the body
    document.body.appendChild(endText)
    //text to be displayed
    endText.innerText = `Please enter a final number:`
    //add the element to the body
    document.body.appendChild(endInput);
    endInput.focus();
    //show button
    document.body.appendChild(endNumbButton);

})

endInput.addEventListener('keypress', (e) => {
    if (e.key == 'Enter') {
        endNumb = endInput.value
        document.body.innerHTML = ""
        document.body.appendChild(printOutput)
        console.log(endNumb)  
       snsInteractive(startNumb, endNumb)
    }
});

endNumbButton.addEventListener('click', (e) => {
    endNumb = endInput.value
    document.body.innerHTML = ""
    document.body.appendChild(printOutput)
    console.log(endNumb) 
    snsInteractive(startNumb, endNumb)
})

//create text element for user promt
let printOutput = document.createElement('h3');
//add the element to the body
document.body.appendChild(printOutput)



function snsInteractive (startNumb, endNumb)
{
    let counter = startNumb;
    let snsCounter = 0
    let swCounter = 0
    let saCounter = 0
    let output = ""

    if (numbValidation(startNumb,endNumb) == true) 
    {
        
        //instantiating array to hole inputs
        let db = []
        
        while (counter <= endNumb) 
        {
            
            //print 40 numbers per line
            for (let i = 1; i < 40; i++) 
            {
                if (counter%5 == 0 && counter%3 == 0) //If number is divisable by 3 and 5
                {
                    output += "<span>SweetnSalty</span>"; //print this
                    snsCounter++; //and count each time sweetnsalty is printed
                }
                else if (counter%5 == 0) //If number is divisable by 5
                {
                    output += "<span>Salty </span>"; //print this
                    saCounter++; //and count each time salty is printed
                    
                }
                else if (counter%3 == 0) //If number is divisiable by 3
                {
                    output += "<span>Sweet </span>"; //print this
                    swCounter++; //and count each time sweet is printed
                }
                else 
                {
                    output += counter + " "; //if not divisible by 3, 5, or both print the number and the other part of the string
                }      
        
                if (counter == endNumb)
                {
                    counter++;
                    break;
                }
                
                counter++;
            }
    
            //text to be displayed
            printOutput.innerHTML = `${output}`
    
        }
        
        //create text element for sweet
        let printSWCounter = document.createElement('h3');
        //add the element to the body
        document.body.appendChild(printSWCounter)
        
        //create text element for salty
        let printSACounter = document.createElement('h3');
        //add the element to the body
        document.body.appendChild(printSACounter)
        
        //create text element for sns
        let printSnSCounter = document.createElement('h3');
        //add the element to the body
        document.body.appendChild(printSnSCounter)

        printSWCounter.innerText = `# of Sweet: ${swCounter}`//print the amount of times the word sweet was printed
        printSACounter.innerText = `# of Salty: ${saCounter}` //print the amount of times the word saly was printed
        printSnSCounter.innerText = `# of SweetnSalty: ${snsCounter}` //print the amount of times the word sweetnsalty was 
    } 
    else 
    {
        console.log('invalid number inputs') //change this to be able to print on screen...later
    }

    //text in game
    endButton.innerText = 'Stop playing'
    //Show start button
    document.body.appendChild(endButton)
    
}

endButton.addEventListener('click', (e) => {
    location.reload();
})

function numbValidation(startNumb, endNumb)
{
    if (startNumb >=0 && endNumb > startNumb)
    {
        if (Math.abs(startNumb-endNumb) >= 200 && Math.abs(startNumb - endNumb) <= 10000)
        {
            return true;
        }
        return false;
    }
    return false;
}