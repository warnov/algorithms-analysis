#include <iostream>

char a[100];

int main()
{
	int cursor, n;
	int t;
	scanf("%d", &t);
	while (t--) {
		scanf("%d", &n);
		scanf("%s", a);
		int total = (int)(a[0] - '0');
		cursor = 0;
		for (int i = 1; i < n; i++) {
			int current = (int)(a[i] - '0');
			if (total == 0)printf("%c", '+');
			else printf("%c", '-');
			total ^= current;
		}
		printf("%c", '\n');
	}
	return 0;
}