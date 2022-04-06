function readMore(more)
{
    var text = document.querySelector('.more');
    var dots = document.querySelector('.dots');
    if(text.style.display === 'none')
    {
    dots.style.display = 'none';
    text.style.display = 'inline';
    more.innerHTML = 'Скрыть';
    }
    else
    {
        dots.style.display = 'inline';
     text.style.display = 'none';
     more.innerHTML = 'Читать больше';
    }
}
function readMorePlot(more)
{
    var text = document.querySelector('.more2');
    // var more = document.querySelector('.about__more');
    var dots = document.querySelector('.dots2');
    if(text.style.display === 'none')
    {
    dots.style.display = 'none';
    text.style.display = 'inline';
    more.innerHTML = 'Скрыть';
    }
    else
    {
        dots.style.display = 'inline';
     text.style.display = 'none';
     more.innerHTML = 'Читать больше';
    }
}

