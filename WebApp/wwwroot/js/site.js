const toggleClass = (element, className, compareValue) => {
    let isFixed = false;
    let _element = document.querySelector(element);
    if(value<=compareValue)
        isFixed = true
    else isFixed=false
    _element.classList.toggle(className,isFixed)
    }
toggleClass("footer","fixed",document.body.scrollHeight,(window.innerHeight-_element.scrollHeight))

