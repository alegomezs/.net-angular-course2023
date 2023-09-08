document.addEventListener("DOMContentLoaded", function(event) {
    let result;
    let score = 20;
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
        score = 20;
        document.getElementById('body').classList.remove('winner');  
        document.getElementById('guess').value =  '';        
        resultText.textContent = '?';
        document.getElementById('highscore').textContent = highScore;
        document.getElementById('score').textContent = score;
        hint.textContent = '';
        generateNumber();
    }

    function guess() {    
        const guessNumber = parseInt(document.getElementById('guess').value);
        const condition = validation(guessNumber);

        if (condition.isValid) {
            if (score !== 0) {     
                if (guessNumber === result) {
                    hint.textContent = 'Numero correcto!';
                    document.getElementById('body').classList.add('winner');                       
                    resultText.textContent = result;            
                    if (score > highScore) {
                        highScore = score;
                    }
                    document.getElementById('score').textContent = highScore;
                    document.getElementById('highscore').textContent = highScore;
                    resultText.textContent = result;                
                } else {            
                    score -= 1;                
                    if (score === 0) {
                        console.log(score);
                        hint.textContent = `Has agotado tus intentos. El número correcto era ${result}.`;            
                        document.getElementById('score').textContent = score;
                        resultText.textContent = result; 
                    } else if (guessNumber < result) {
                        hint.textContent = 'Muy bajo!';
                        document.getElementById('score').textContent = score; 
                    } else {
                        hint.textContent = 'Muy Alto!';
                        document.getElementById('score').textContent = score; 
                    }
                }
            } else {
                hint.textContent = `Chuck Norris lo hubiera hecho menos intentos. Debes reiniciar el juego!`;
            }                  
        }
        else {
            hint.textContent = condition.message;
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