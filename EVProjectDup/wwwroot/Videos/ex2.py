s1 = input()  # First string
s2 = input()  # Second string

count = 0  # Initialize count to 0

for i in range(len(s1)):
    if s1[i] != '?' and s2[i] != '?' and s1[i] == s2[i]:
        count += 1
        
print(count)