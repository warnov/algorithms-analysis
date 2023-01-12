// const readline = require('readline');

// const rl = readline.createInterface({ input: process.stdin, output: process.stdout });
// const prompt = (query) => new Promise((resolve) => rl.question(query, resolve));

// (async() => {  
//     t = await prompt('');
//     while(t--){
//         n = await prompt('');
//         while(n%2==0)n/=2;
//         if(n!=1)console.log('YES');
//         else console.log('NO');
//     }
//     rl.close();
// })();

// // When done reading prompt, exit program 
// rl.on('close', () => process.exit(0));




/************* KEEP BELOW CODE AS IT IS *********************/
/**
 * This code has been taken from: https://codeforces.com/blog/entry/69610
 * I am not the owner of the readLine function below, understanding them require knowledge of basic NodeJS I/O and streams
 */
process.stdin.resume()
process.stdin.setEncoding('utf-8')

let currentLine = 0
let inputString = ''

process.stdin.on('data', raw_data => {
    inputString += raw_data
})

process.stdin.on('end', _ => {
    inputString = inputString.trim().split('\n').map(line => {
        return line.trim()
    })
    main()
})

function readLine() {
    return inputString[currentLine++]
}

function main() {
    let t = readLine();
    t = parseInt(t);  
    while(t--) {
        let line = readLine();       
        let n = parseInt(line);
        while(n%2==0)n/=2;
        if(n!=1)console.log('YES');
        else console.log('NO');}
}