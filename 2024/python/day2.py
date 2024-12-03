def is_safe(report):
    return all(1 <= n <= 3 for n in report) or all(-1 >= n >= -3 for n in report)


with open('../inputs/Day2.txt') as f:
    data = [list(map(int, filter(None, line.split()))) for line in f]

# safe_reports = sum(
#     1 for i in range(len(data))
#     if is_safe([data[i][j] - data[i][j - 1] for j in range(1, len(data[i]))])
# )

safe_reports = 0
safe_reports_with_skip = 0
for report in data:
    if is_safe([report[j] - report[j - 1] for j in range(1, len(report))]):
        safe_reports += 1
        safe_reports_with_skip += 1
    else:
        for skip in range(len(report)):
            diff = [
                report[j + 1] - report[j - 1] if j == skip else report[j] - report[j - 1]
                for j in range(1, len(report) - (1 if skip == len(report) - 1 else 0))
                if j - 1 != skip
            ]
            if is_safe(diff):
                safe_reports_with_skip += 1
                break

print(f'Part 1: {safe_reports}')
print(f'Part 2: {safe_reports_with_skip}')
