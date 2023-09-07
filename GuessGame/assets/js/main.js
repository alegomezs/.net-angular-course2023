document.addEventListener("DOMContentLoaded", function(event) {
    let result;
    let score = 10;
    let highScore = 0;
    let hint = document.getElementById('hint-text');
    let resultText =  document.getElementById('result');
    let send =  document.getElementById('send');
    let reset =  document.getElementById('reset');      

    send.addEventListener('click', function(event){
        event.preventDefault()
      });
    reset.addEventListener('click', function(event){
        event.preventDefault()
    });

    reset.addEventListener('click', resetGame);
    send.addEventListener('click', guess);
    
    generateNumber();

    function generateNumber() {
        result = Math.floor(Math.random() * 20) + 1;
    }

    function resetGame() {
        score = 0   ;
        resultText.textContent = '?';
        document.getElementById('highscore').textContent = highScore;
        hint.textContent = '';
        generateNumber();
    }

    function guess() {
        const guessNumber = parseInt(document.getElementById('guess').value);

        if (guessNumber === result) {
            hint.textContent = 'Numero correcto!';
            document.getElementsByTagName('body').classList.add('winner').    
            resultText.textContent = result;
            score += 1;
            if (score > highScore) {
                highScore = score;
            }
            document.getElementById('score').textContent = highScore;
            document.getElementById('highscore').textContent = highScore;
            resultText.textContent = result;                
        } else {
            score -= 1;
            if (score === 0) {
                hint.textContent = `Has agotado tus intentos. El número correcto era ${result}.`;
                resetGame();
            } else if (guessNumber < result) {
                hint.textContent = 'Muy bajo!';
            } else {
                hint.textContent = 'Muy Alto!';
            }
        }
    }
});            