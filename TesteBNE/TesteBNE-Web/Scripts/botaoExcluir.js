$(document).ready(function () {
	console.log("carregando...");
	$("#confirm").load("/Shared/ModalExcluir.html");
	// Get the modal
	var modal = document.getElementById('confirm');

	// When the user clicks anywhere outside of the modal, close it
	window.onclick = function (event) {
		if (event.target === modal) {
			modal.style.display = "none";
		}
	};
})