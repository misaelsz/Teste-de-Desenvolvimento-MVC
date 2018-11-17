

function post(pessoa) {
	$.ajax({

		url: 'http://localhost:63689/api/Aluno',
		data: pessoa,
		type: 'POST',
		contentType: 'application/json; charset=UTF-8',
		success: (function (retorno) {
			console.log("pessoa :" + pessoa + "success");
			console.log("data :" + retorno);
			alert("Cadastro efetuado com sucesso.");
			var url = location.href;
			url = url.split("/")[0] + "/index.html";
			window.location.assign(url);
		}),
		error: (function (retorno) {
			console.log("pessoa :" + pessoa + "success");
			console.log("data :" + retorno);
			console.log(retorno);
			if (retorno.status == 400) {
				alert("Usuário já cadastrado!");
			} else {
				alert("Algum erro inesperado ocorreu :-(!.");
			}

		})

	});
}