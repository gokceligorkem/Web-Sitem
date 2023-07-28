
// Typewriter 
const typedTextSpans = document.querySelectorAll('.typed-text');
const typingDelay = 100; // Yazma hızını belirleyebilirsiniz, burada 100ms kullanıldı
const deletionDelay = 50; // Silme hızını belirleyebilirsiniz, burada 50ms kullanıldı
const newTextDelay = 2000; // Yeni metne geçiş süresini belirleyebilirsiniz, burada 2000ms (2 saniye) kullanıldı

typedTextSpans.forEach(typedTextSpan => {
    const text = typedTextSpan.textContent;
    let charIndex = 0;

    function type() {
        if (charIndex < text.length) {
            typedTextSpan.textContent += text.charAt(charIndex);//charAt dizideki belirli konumdaki karakteri döndürür. 
            charIndex++;
            setTimeout(type, typingDelay);
        } else {
            setTimeout(erase, newTextDelay);
        }
    }
    //charIndexi >0dan büyük olduğunda başlatılacak fonksiyon
    function erase() {
        if (charIndex > 0) {
            typedTextSpan.textContent = text.substring(0, charIndex - 1);
            charIndex--;
            setTimeout(erase, deletionDelay);
        } else {
            setTimeout(type, typingDelay + 1100);
        }
    }

    // Metini temizle ve animasyona başla - foreach ile gelen ilk değer silinmeli
    typedTextSpan.textContent = "";
    setTimeout(type, newTextDelay + 250);
});
//Featurapage Rain 
