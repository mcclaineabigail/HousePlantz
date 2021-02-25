var addModal = document.getElementById("outer-add");

var addButton = document.getElementById("button-add");

var addSpan = document.getElementsById("close-add");


addButton.onclick = function() {
  addModal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
addSpan.onclick = function() {
    addModal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == addModal) {
    addModal.style.display = "none";
  }
}