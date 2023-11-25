process.stdin.on('data', function (data) {
    const dataToArray = data.toString().split('\n');
    const [n, m] = dataToArray[0].split(' ').map(n => +n);
    const memoizedSum = Array.from({length: n}, () => Array.from({length: m}, () => Array(2).fill(-Infinity)));
    const intData = dataToArray.slice(1).map((str, index) => str.split(' ').map(n => +n)).slice(0, n);

    intData[0].map((num, index) => {
        if (num % 2 === 0) {
            memoizedSum[0][index][0] = num;
        } else {
            memoizedSum[0][index][1] = num;
        }
    })

    const getPrevMaxSum = (i, j, p) => {
        const prevLeftMaxSum = memoizedSum[i - 1][j > 0 ? j - 1 : 0].find(v => v !== -Infinity);
        const prevCenterMaxSum = memoizedSum[i - 1][j].find(v => v !== -Infinity);
        const prevRightMaxSum = memoizedSum[i - 1][j < m - 1 ? j + 1 : m - 1].find(v => v !== -Infinity);

        return Math.max(prevLeftMaxSum, Math.max(prevCenterMaxSum, prevRightMaxSum));
    }

    for (let  i = 1; i < n; i++) {
        intData[i].forEach((num, j) => {
            const prevMaxSum = getPrevMaxSum(i, j);
            const currSum = num + prevMaxSum
            memoizedSum[i][j][currSum % 2 === 0 ? 0 : 1] = currSum;
        })
    }

    console.log(memoizedSum[n - 1].sort((a, b) => b[1] - a[1])[0][1] || 'impossible');
});
