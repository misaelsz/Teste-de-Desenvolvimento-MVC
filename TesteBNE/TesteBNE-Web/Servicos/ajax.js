
//function postAluno(aluno) {
//	console.log("dentro do post" + aluno)
//	$.post("http://localhost:63689/api/Aluno", aluno, function () { }, 'json')
//};

function postAluno(pessoa) {
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
			url = url.split("/")[0] + "/Aluno/IndexAluno";
			window.location.assign(url);
		}),
		error: (function (retorno) {
			console.log("pessoa :" + pessoa + "success");
			console.log("data :" + retorno);
			console.log(retorno);
			if (retorno.status === 400) {
				alert("Usuário já cadastrado!");
			} else {
				alert("Algum erro inesperado ocorreu :-(!.");
			}

		})

	});
}

function postDisciplina(Disciplina) {
	$.ajax({

		url: 'http://localhost:63689/api/Disciplina',
		data: Disciplina,
		type: 'POST',
		contentType: 'application/json; charset=UTF-8',
		success: (function (retorno) {
			console.log("pessoa :" + Disciplina + "success");
			console.log("data :" + retorno);
			alert("Cadastro efetuado com sucesso.");
			var url = location.href;
			url = url.split("/")[0] + "/Disciplina/IndexDisciplina";
			window.location.assign(url);
		}),
		error: (function (retorno) {
			console.log("pessoa :" + Disciplina + "success");
			console.log("data :" + retorno);
			console.log(retorno);
				alert("Algum erro inesperado ocorreu :-(!.");
			})

		

	});
}

function get(funcao) {
	$.ajax({
		url: 'http://localhost:63689/api/Aluno',
		method: 'GET'
	}).done(function (data) {
		funcao(data);
	});
}

function getDisciplinas(funcao) {
	$.ajax({
		url: 'http://localhost:63689/api/Disciplina',
		method: 'GET'
	}).done(function (data) {
		console.log("retono: " + data);
		console.log("...");
		funcao(data);
	});
}


function getDisciplinasPorAluno() {
	
	$.ajax({
		url: 'http://localhost:63689/api/Disciplina/Vincular/' + location.href.split("/")[5],
		method: 'GET'
	}).done(function (data) {
		console.log("retono: " + JSON.stringify(data));
		console.log("...");

		listarParaVinculo(data);
	});
}

function getPorId(id) {
	$.ajax({
		url: 'http://localhost:63689/api/Aluno/' + id,
		method: 'GET',
		contentType: 'application/json; charset=UTF-8',
	}).then(function (resposta) {
		console.log("dentro da requisicao" + resposta);
		editar(resposta);
	})

}

function retornaDisciplinaPorId(id) {
	var disciplina;
	$.ajax({
		url: 'http://localhost:63689/api/Disciplina/' + id,
		method: 'GET',
		contentType: 'application/json; charset=UTF-8',
		async: false
	}).then(function (resposta) {
		console.log("dentro da requisicao" + resposta);
		disciplina = retornaValor(resposta);
	});
	return disciplina;
}

function getDisciplinaPorId(id) {
	var disciplina;
	$.ajax({
		url: 'http://localhost:63689/api/Disciplina/' + id,
		method: 'GET',
		contentType: 'application/json; charset=UTF-8',
		async: false
	}).then(function (resposta) {
		console.log("dentro da requisicao" + resposta);
		editarDisciplina(resposta);
		disciplina = retornaValor(resposta);
		});
	return disciplina;
}


function put(id, pessoa) {
	$.ajax({
		url: 'http://localhost:63689/api/Aluno/' + id,
		method: 'PUT',
		data: JSON.stringify(pessoa),
		contentType: 'application/json; charset=UTF-8',
	}).then(function (a) {
		alert("sucesso");
		console.log("retorno put" + a);
		window.location.assign("./IndexAluno");
	})
}

function putDisciplina(id, disciplina) {
	console.log("Dentro da requisição\n" +
		"valor do id: " + id
		+ "Disciplina: " + JSON.stringify(disciplina));
	$.ajax({
		url: 'http://localhost:63689/api/Disciplina/' + id,
		method: 'PUT',
		async:false,
		data: JSON.stringify(disciplina),
		contentType: 'application/json; charset=UTF-8',
	}).then(function (a) {
		alert("sucesso");
		console.log("retorno put" + a);
		window.location.assign("./IndexDisciplina");
	})
}


function Delete(id) {
	$.ajax({
		url: 'http://localhost:63689/api/Aluno/' + id,
		method: 'DELETE',
		contentType: 'application/json; charset=UTF-8',
	}).then(function (e) {
		$("#remover").parent().parent().parent().remove();
		var ObjPessoa = null;
		$.ajax({
			url: 'http://localhost:63689/api/Aluno',
			method: 'GET'
		}).done(function (data) {
			ObjPessoa = [];
			ObjPessoa = data;
			console.log("data Json" + JSON.stringify(data));

			console.log("objJSON : " + ObjPessoa);
			var url = location.href;
			url = url.split("/")[0] + "/Aluno/IndexAluno";
			window.location.assign(url);
		});
	})
}

function DeleteDisciplina(id) {
	$.ajax({
		url: 'http://localhost:63689/api/Disciplina/' + id,
		method: 'DELETE',
		contentType: 'application/json; charset=UTF-8',
	}).then(function (e) {
		$("#remover").parent().parent().parent().remove();
		var ObjPessoa = null;
		$.ajax({
			url: 'http://localhost:63689/api/Disciplina',
			method: 'GET'
		}).done(function (data) {
			ObjPessoa = [];
			ObjPessoa = data;
			console.log("data Json" + JSON.stringify(data));

			console.log("objJSON : " + ObjPessoa);
			var url = location.href;
			url = url.split("/")[0] + "/Disciplina/IndexDisciplina";
			window.location.assign(url);
		});
	})
}

function editar(resposta) {
	var e = resposta;
	console.log("retorno do callback" + e);

	console.log("retorno: " + JSON.stringify(e.Nome_Aluno));
	document.getElementById('txtNomeAluno').value = e.Nome_Aluno;


	$('#bntCadAluno').click(function () {

		e.Nome_Aluno = document.getElementById('txtNomeAluno').value;

		console.log("valores do objeto e" + e.Nome_Aluno);

		var id = e.ID;
		var pessoa = e;
		put(id, pessoa);
	});
}

function editarDisciplina(resposta) {
	var e = resposta;
	console.log("retorno do callback" + e);
	console.log("objeto de retorno stringfy: " + JSON.stringify(e));
	console.log("retorno: " + JSON.stringify(e.Nome_Disciplina));
	document.getElementById('txtNomeDisciplina').value = e.Nome_Disciplina;


	$('#bntCadDisciplina').click(function () {

		e.Nome_Disciplina = document.getElementById('txtNomeDisciplina').value;

		console.log("valores do objeto e" + e.Nome_Disciplina);

		var id = e.ID;
		var disciplina = e;
		putDisciplina(id, disciplina);
	});
}

function listarParaVinculo(ObjPessoa) {
	$.each(ObjPessoa, function (chave, valor) {
		$("#listVincular").append(
			"<tr>" +
			"<td>" + valor.Nome_Disciplina + "</td>" +
			"<td><button type='button' onclick='vincular(" + JSON.stringify(valor.ID) + ")'; class='btn btn-warning'>Vincular</button></td>"
		);
	});
}

function AbreAdicionar(id) {
	var url = location.href;
	url = url.split("/")[0] + "/Disciplina/AdicionarDisciplina/" +id;
	window.location.assign(url);
}

function retornaValor(dado) {
	return dado;
}

