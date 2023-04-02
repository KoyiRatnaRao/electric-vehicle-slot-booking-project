n = int(input())
for i in range(1, n+1):
    for j in range(1, n*2):
        if j == i or j == n*2-i:
            print(i, end='')
        else:
            print(' ', end='')
    print()
for i in range(n-1, 0, -1):
    for j in range(1, n*2):
        if j == i or j == n*2-i:
            print(i, end='')
        else:
            print(' ', end='')
    print()
