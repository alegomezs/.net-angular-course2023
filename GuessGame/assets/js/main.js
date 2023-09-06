        let result;
        let score = 10;
        let highScore = 0;
        let message = document.getElementById('message');
        let resultText =  document.getElementById('result');
        
        document.getElementById('reset').addEventListener('click', resetGame);
        document.getElementById('send').addEventListener('click', guess);
        
        generateNumber();

        function generateNumber() {
            result = Math.floor(Math.random() * 100) + 1;
        }

        function resetGame() {
            score = 10;
            resultText.innerText('?');
            document.getElementById('highscore').textContent = highScore;
            message.textContent = '';
            generateNumber();
        }

        function guess() {
            const guessNumber = parseInt(document.getElementById('guess').value);

            if (guessNumber === result) {
                message.textContent = '¡Felicidades! Has adivinado el número correctamente.';
                score += 1;
                if (score > highScore) {
                    highScore = score;
                }
                resultText.innerText(result);                
            } else {
                score -= 1;
                if (score === 0) {
                    message.textContent = `Has agotado tus intentos. El número correcto era ${result}.`;
                    resetGame();
                } else if (guessNumber < result) {
                    message.textContent = 'El número es mayor. Inténtalo de nuevo.';
                } else {
                    message.textContent = 'El número es menor. Inténtalo de nuevo.';
                }
            }
        }

      
        
        
    