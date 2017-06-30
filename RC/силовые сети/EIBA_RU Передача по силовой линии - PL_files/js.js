  led0 = new Image(6,10)
  led0.src = "images/led0.gif"
  led00 = new Image(6,10)
  led00.src = "images/led00.gif"
  led1 = new Image(6,10)
  led1.src = "images/led1.gif"
  function l1(k) 
        {   eval( "document.images.h" + k + ".src = led1.src")
        }
  function l0(k)
	{   if (k<100) {eval( "document.images.h" + k + ".src = led0.src")}
	   else {eval( "document.images.h" + k + ".src = led00.src")}
  	}
