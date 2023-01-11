//package main

// import (
// 	"fmt"
// )

// func main() {
// 	var nTests int
// 	fmt.Scan(&nTests)
// 	var result []byte=make([]byte, 0)

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		fmt.Scan(&length)
// 		var a string
// 		fmt.Scan(&a)
// 		var total=int(a[0]-'0')
// 		for j := 1; j < length; j++ {
// 			var current int=int(a[j]-'0')

// 			if current == 0 {
// 				result = append(result, '+')
// 			}else{
// 				if(total==0){
// 					result = append(result, '+')
// 					total=1;
// 				}else{
// 					result = append(result, '-')
// 					total=0;
// 				}
// 			}
// 		}
// 		result = append(result, '\n')
// 	}
// 	fmt.Println(string(result[:]))
// }

// //Using Byte Buffer
// package main

// import(
// 	"fmt"
// 	"bytes"
// )

// func main() {
// 	var nTests int
// 	fmt.Scan(&nTests)
// 	var result bytes.Buffer

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		fmt.Scan(&length)
// 		var a string
// 		fmt.Scan(&a)
// 		var total=int(a[0]-'0')
// 		for j := 1; j < length; j++ {
// 			var current int=int(a[j]-'0')

// 			if current == 0 {
// 				result.WriteRune('+')
// 			}else{
// 				if(total==0){
// 					result.WriteRune('+')
// 					total=1;
// 				}else{
// 					result.WriteRune('-')
// 					total=0;
// 				}
// 			}
// 		}
// 		result.WriteRune('\n')
// 	}
// 	fmt.Println(result.String())
// }

// Using string split into chars
// package main

// import (
// 	"bytes"
// 	"fmt"
// 	"strconv"
// 	"strings"
// )

// func main() {
// 	var nTests int
// 	fmt.Scan(&nTests)
// 	var result bytes.Buffer

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		fmt.Scan(&length)
// 		var a string
// 		fmt.Scan(&a)
// 		var elements=strings.Split(a,"")
// 		var total, _ = strconv.Atoi(elements[0])
// 		for j := 1; j < length; j++ {
// 			var current, _=strconv.Atoi(elements[j])

// 			if current == 0 {
// 				result.WriteRune('+')
// 			}else{
// 				if(total==0){
// 					result.WriteRune('+')
// 					total=1;
// 				}else{
// 					result.WriteRune('-')
// 					total=0;
// 				}
// 			}
// 		}
// 		result.WriteRune('\n')
// 	}
// 	fmt.Println(result.String())
// }


// // Removing fmt and using sb for output. Removing bytes buffer and writting directly to stdout
// //permanently writting increases a lot the execution time (the same happens in .net)
// package main

// import (
// 	"bufio"
// 	"os"
// 	"strconv"
// 	"strings"
// )

// func main() {
// 	var nTests int
// 	inputBuffer := bufio.NewReader(os.Stdin)
// 	var sTests, _ = inputBuffer.ReadString('\n')
// 	nTests, _ = strconv.Atoi(strings.TrimSpace(sTests))

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		var sLength, _ = inputBuffer.ReadString('\n')
// 		length, _ = strconv.Atoi(strings.TrimSpace(sLength))
// 		var a, _ = inputBuffer.ReadString('\n')
// 		var elements = strings.Split(a, "")
// 		var total, _ = strconv.Atoi(elements[0])
// 		for j := 1; j < length; j++ {
// 			var current, _ = strconv.Atoi(elements[j])

// 			if current == 0 {
// 				sb.WriteRune("+")
// 			} else {
// 				if total == 0 {
// 					sb.WriteRune("+")
// 					total = 1
// 				} else {
// 					sb.WriteRune("-")
// 					total = 0
// 				}
// 			}
// 		}
// 		sb.WriteRune("\n")
// 	}
// }

// // Using s stringbuilder
// package main

// import (
// 	"bufio"
// 	"os"
// 	"strconv"
// 	"strings"
// )

// func main() {
// 	var nTests int
// 	inputBuffer := bufio.NewReader(os.Stdin)
// 	var sTests, _ = inputBuffer.ReadString('\n')
// 	nTests, _ = strconv.Atoi(strings.TrimSpace(sTests))
// 	var sb strings.Builder

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		var sLength, _ = inputBuffer.ReadString('\n')
// 		length, _ = strconv.Atoi(strings.TrimSpace(sLength))
// 		var a, _ = inputBuffer.ReadString('\n')
// 		var elements = strings.Split(a, "")
// 		var total, _ = strconv.Atoi(elements[0])
// 		for j := 1; j < length; j++ {
// 			var current, _ = strconv.Atoi(elements[j])

// 			if current == 0 {
// 				sb.WriteRune("+")
// 			} else {
// 				if total == 0 {
// 					sb.WriteRune("+")
// 					total = 1
// 				} else {
// 					sb.WriteRune("-")
// 					total = 0
// 				}
// 			}
// 		}
// 		sb.WriteRune("\n")
// 	}
// 	os.Stdout.WriteRune(sb.String())
// }


// // Using byte buffer instead of string builder and not fmt
// package main

// import (
// 	"bufio"
// 	"os"
// 	"strconv"
// 	"strings"
// 	"bytes"
// )

// func main() {
// 	var nTests int
// 	inputBuffer := bufio.NewReader(os.Stdin)
// 	var sTests, _ = inputBuffer.ReadString('\n')
// 	nTests, _ = strconv.Atoi(strings.TrimSpace(sTests))
// 	var result bytes.Buffer

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		var sLength, _ = inputBuffer.ReadString('\n')
// 		length, _ = strconv.Atoi(strings.TrimSpace(sLength))
// 		var a, _ = inputBuffer.ReadString('\n')
// 		var elements = strings.Split(a, "")
// 		var total, _ = strconv.Atoi(elements[0])
// 		for j := 1; j < length; j++ {
// 			var current, _ = strconv.Atoi(elements[j])

// 			if current == 0 {
// 				result.WriteRune("+")
// 			} else {
// 				if total == 0 {
// 					result.WriteRune("+")
// 					total = 1
// 				} else {
// 					result.WriteRune("-")
// 					total = 0
// 				}
// 			}
// 		}
// 		result.WriteRune("\n")
// 	}
// 	os.Stdout.WriteRune(result.String())
// }


// Using byte buffer with runes instead of string builder and not fmt
// package main

// import (
// 	"bufio"
// 	"os"
// 	"strconv"
// 	"strings"
// 	"bytes"
// )

// func main() {
	
// 	var inputBuffer = bufio.NewReader(os.Stdin)
// 	var sTests, _ = inputBuffer.ReadString('\n')
// 	var nTests int
// 	nTests, _ = strconv.Atoi(strings.TrimSpace(sTests))
// 	var result bytes.Buffer

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		var sLength, _ = inputBuffer.ReadString('\n')
// 		length, _ = strconv.Atoi(strings.TrimSpace(sLength))
// 		var a, _ = inputBuffer.ReadString('\n')
// 		var total = int(a[0]-'0')
// 		for j := 1; j < length; j++ {
// 			var current= int(a[j]-'0')

// 			if current == 0 {
// 				result.WriteRune('+')
// 			} else {
// 				if total == 0 {
// 					result.WriteRune('+')
// 					total = 1
// 				} else {
// 					result.WriteRune('-')
// 					total = 0
// 				}
// 			}
// 		}
// 		result.WriteRune('\n')
// 	}
// 	os.Stdout.WriteString(result.String())
// }


// // Using XOR, byte buffer with runes instead of string builder and not fmt
// package main

// import (
// 	"bufio"
// 	"os"
// 	"strconv"
// 	"strings"
// 	"bytes"
// )

// func main() {
	
// 	var inputBuffer = bufio.NewReader(os.Stdin)
// 	var sTests, _ = inputBuffer.ReadString('\n')
// 	var nTests int
// 	nTests, _ = strconv.Atoi(strings.TrimSpace(sTests))
// 	var result bytes.Buffer

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		var sLength, _ = inputBuffer.ReadString('\n')
// 		length, _ = strconv.Atoi(strings.TrimSpace(sLength))
// 		var a, _ = inputBuffer.ReadString('\n')
// 		var total = int(a[0]-'0')
// 		for j := 1; j < length; j++ {
// 			var current= int(a[j]-'0')

// 			if current == 0 {
// 				result.WriteRune('+')
// 			} else { 
// 				result.WriteRune((rune)(43 + 2 * total))
// 				total ^= current
// 			}
// 		}
// 		result.WriteRune('\n')
// 	}
// 	os.Stdout.WriteString(result.String())
// }


// Using XOR, runes convertion and fmt: FMT SUCKS!!!
// package main

// import (	
// 	"os"
// 	"bytes"
// 	"fmt"
// )

// func main() {
	
// 	var nTests int
// 	fmt.Scan(&nTests)
// 	var result bytes.Buffer

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		fmt.Scan(&length)
// 		var a string
// 		fmt.Scan(&a)
// 		var total = int(a[0]-'0')
// 		for j := 1; j < length; j++ {
// 			var current= int(a[j]-'0')

// 			if current == 0 {
// 				result.WriteRune('+')
// 			} else { 
// 				result.WriteRune((rune)(43 + 2 * total))
// 				total ^= current
// 			}
// 		}
// 		result.WriteRune('\n')
// 	}
// 	os.Stdout.WriteString(result.String())
// }


// // Using XOR, byte buffer with runes instead of string builder, not fmt and continues
// package main

// import (
// 	"bufio"
// 	"os"
// 	"strconv"
// 	"strings"
// 	"bytes"
// )

// func main() {
	
// 	var inputBuffer = bufio.NewReader(os.Stdin)
// 	var sTests, _ = inputBuffer.ReadString('\n')
// 	var nTests int
// 	nTests, _ = strconv.Atoi(strings.TrimSpace(sTests))
// 	var result bytes.Buffer

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		var sLength, _ = inputBuffer.ReadString('\n')
// 		length, _ = strconv.Atoi(strings.TrimSpace(sLength))
// 		var a, _ = inputBuffer.ReadString('\n')
// 		var total = int(a[0]-'0')
// 		for j := 1; j < length; j++ {
// 			var current= int(a[j]-'0')

// 			if current == 0 {
// 				result.WriteRune('+')
// 				continue
// 			} 
// 			if total == 0 { 
// 				result.WriteRune('+')
// 				total ^= current
// 				continue
// 			}
// 			result.WriteRune('-')
// 			total ^= current
// 		}
// 		result.WriteRune('\n')
// 	}
// 	os.Stdout.WriteString(result.String())
// }



// // Using XOR, rune append, not fmt and continues
// package main

// import (
// 	"bufio"
// 	"os"
// 	"strconv"
// 	"strings"
// )

// func main() {
	
// 	var inputBuffer = bufio.NewReader(os.Stdin)
// 	var sTests, _ = inputBuffer.ReadString('\n')
// 	var nTests int
// 	nTests, _ = strconv.Atoi(strings.TrimSpace(sTests))
// 	var result []rune

// 	for i := 0; i < nTests; i++ {
// 		var length int
// 		var sLength, _ = inputBuffer.ReadString('\n')
// 		length, _ = strconv.Atoi(strings.TrimSpace(sLength))
// 		var a, _ = inputBuffer.ReadString('\n')
// 		var total = int(a[0]-'0')
// 		for j := 1; j < length; j++ {
// 			var current= int(a[j]-'0')

// 			if current == 0 {
// 				result=append(result,'+')
// 				continue
// 			} 
// 			if total == 0 { 
// 				result=append(result,'+')
// 				total ^= current
// 				continue
// 			}
// 			result=append(result,'-')
// 			total ^= current
// 		}
// 		result=append(result,'\n')
// 	}
// 	os.Stdout.WriteString(string(result))
// }


//With Pierre optimizations and removing strings lib
package main
 
import (
	"bufio"
	"os"
	"strconv"
	"strings"
)
 
func main() {
    inputBuffer := bufio.NewReader(os.Stdin)
    snTests,_ := inputBuffer.ReadString('\n')
	var result strings.Builder
	for t,_ := strconv.Atoi(snTests[:len(snTests)-2]); t > 0; t-- {
	    sLength,_ := inputBuffer.ReadString('\n')
		n,_ := strconv.Atoi(sLength[:len(sLength)-2])
		a,_ := inputBuffer.ReadString('\n')		
		total := int(a[0] - '0')
		
 
		for i := 1; i < n; i++ {
			if total == 1 {
				result.WriteString("-")
			} else {
				result.WriteString("+")
			}
			total ^= int(a[i] - '0')
		}	
		os.Stdout.WriteString(result.String()+"\n")	
		result.Reset()
	}	
}