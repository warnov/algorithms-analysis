#include <iostream>
#include<math.h>


int main() {
    int t;
    scanf("%d", &t);
    while (t--) {
        long long n;
        long double  m;
        scanf("%lld", &n);
        m = log2l(n);
        if (m == floorl(m)) {
            printf("NO\n");
        }
        else {
            printf("YES\n");
        }
    }
}



