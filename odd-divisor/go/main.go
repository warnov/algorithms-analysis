// package main
 
// import (
// 	"bufio"
// 	"os"
// 	"strconv"
// 	"math"
// )
 
// func main() {
//     inputBuffer := bufio.NewReader(os.Stdin)
//     snTests,_ := inputBuffer.ReadString('\n')
// 	for t,_ := strconv.Atoi(snTests[:len(snTests)-2]); t > 0; t-- {	   
// 		sn,_ := inputBuffer.ReadString('\n')
// 		n,_ := strconv.ParseInt(sn[:len(sn)-2], 10, 64)	
// 		_, decimal:=math.Modf((math.Log2(float64(n))))
// 		if(decimal!=0){
// 			os.Stdout.WriteString("YES\n")
// 		}else{
// 			os.Stdout.WriteString("NO\n")
// 		}			
// 	}
// }

package main
 
import (
	"bufio"
	"os"
	"strconv"
	"fmt"	
	"math"
)

var sc = bufio.NewScanner(os.Stdin)
var wr = bufio.NewWriter(os.Stdout)
 
func main() {
	defer wr.Flush()
	sc.Buffer(make([]byte, 0), 1000000009)
	sc.Split(bufio.ScanWords)

	sc.Scan()
	for t,_ := strconv.Atoi(sc.Text()); t > 0; t-- {
		sc.Scan()
		n,_ := strconv.ParseInt(sc.Text(), 10, 64)				   		
		_, decimal:=math.Modf((math.Log2(float64(n))))
 		if(decimal!=0){
			fmt.Fprint(wr, "YES\n")
		} else {
			fmt.Fprint(wr, "NO\n")
		}	
	}
}