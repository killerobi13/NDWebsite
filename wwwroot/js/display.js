
window.display = (name) => {
    $(name).css({ "position": "relative", "opacity": 0, "left": "+=100" });
    $(name).animate({ left: 0, opacity: 1 }, 2000);
  };


 