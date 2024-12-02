with open('../inputs/Day1.txt', 'r') as f:
    data = [list(map(int, filter(None, line.split()))) for line in f]

left, right = zip(*data)

p1 = sum([abs(r - l) for l, r in zip(sorted(left), sorted(right))])
p2 = sum([n * right.count(n) for n in left])

print(f'Part 1: {p1}')
print(f'Part 2: {p2}')
