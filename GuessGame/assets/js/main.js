document.addEventListener("DOMContentLoaded", function(event) {
    let result;
    let score = 20;
    let highScore = 0;
    let hintElement = document.getElementById('hint-text');
    let resultElement =  document.getElementById('result');
    let sendElement =  document.getElementById('send');
    let resetElement =  document.getElementById('reset');  
    let scoreElement = document.getElementById('score');    
    let highScoreElement = document.getElementById('highscore');

    sendElement.addEventListener('click', function(event){
        event.preventDefault()
      });
    resetElement.addEventListener('click', function(event){
        event.preventDefault()
    });

    resetElement.addEventListener('click', resetGame);
    sendElement.addEventListener('click', guess);
    
    generateNumber();

    function generateNumber() {
        result = Math.floor(Math.random() * 20) + 1;
    }

    function resetGame() {
        score = 20;
        document.getElementById('body').classList.remove('winner');  
        document.getElementById('guess').value =  '';        
        resultElement.textContent = '?';
        highScoreElement.textContent = highScore;
        scoreElement.textContent = score;
        hintElement.textContent = '';
        generateNumber();
    }

    function guess() {    
        const guessNumber = parseInt(document.getElementById('guess').value);
        const condition = validation(guessNumber);

        if (condition.isValid) {
            if (score !== 0) {     
                if (guessNumber === result) {
                    hintElement.textContent = 'Numero correcto!';
                    document.getElementById('body').classList.add('winner');                       
                    resultElement.textContent = result;            
                    if (score > highScore) {
                        highScore = score;
                    }
                    scoreElement.textContent = highScore;
                    highScore.textContent = highScore;
                    resultElement.textContent = result;                
                } else {            
                    score -= 1;                
                    if (score === 0) {
                        console.log(score);
                        hintElement.textContent = `Has agotado tus intentos. El número correcto era ${result}.`;            
                        scoreElement.textContent = score;
                        resultElement.textContent = result; 
                    } else if (guessNumber < result) {
                        hintElement.textContent = 'Muy bajo!';
                        scoreElement.textContent = score; 
                    } else {
                        hintElement.textContent = 'Muy Alto!';
                        scoreElement.textContent = score; 
                    }
                }
            } else {
                hintElement.textContent = `Chuck Norris lo hubiera hecho menos intentos. Debes reiniciar el juego!`;
            }                  
        }
        else {
            hintElement.textContent = condition.message;
        }
    }

    function validation(generateNumber) {
        const guessNumber = parseInt(document.getElementById('guess').value);
        const validation = {
            isValid : false,
            message : "",
        };
        if (!isNaN(guessNumber)) {            
            if (guessNumber > 0 && guessNumber <= 20) {
                validation.isValid = true;
                return validation;
            }
            else {
                validation.message = 'Debe ingresar un valor entre 1 y 20!';                            
            }
        } 
        else {
            validation.message = 'Debe ingresar un valor numérico!';
        }   
        return validation;
    }
});            