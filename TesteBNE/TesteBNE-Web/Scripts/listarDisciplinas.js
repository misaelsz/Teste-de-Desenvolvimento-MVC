document.write(unescape("%3Cscript src='/Servicos/ajax.js' type='text/javascript'%3E%3C/script%3E"));

function listarDisciplinas(ObjPessoa) {
	console.log(ObjPessoa);
	$.each(ObjPessoa, function (chave, valor) {
		//adicionando os objetos dentro da tabela com o comando append
		$("#listaDisciplinas tbody").append(
			"<tr>" +
			"<td>" + valor.Nome_Disciplina + "</td>" +
			// "<td class='btn-primary'><a href='file:///C:/Users/misaelzeferino/Documents/projetosAulaMarth/aula02Ajax/cadastro.html'><button type='button' onclick='editar(" + JSON.stringify(valor.id) + "); ' id='editar'>Editar</button></a></td>" +
			"<td><button type='button' onclick='carregarCadastroParaEdicao(" + JSON.stringify(valor.ID) + "); ' id='editar' class='btn btn-warning'>Editar</button></td>" +
			"<td><button class='btn btn-danger' type='button' onclick='excluirDisciplina(" + JSON.stringify(valor.ID) + ");' id='remover' data-toggle='modal' data-target='#ExcluirConfirm'>X</button></td>"

		);
	});
}



function carregarCadastroParaEdicao(id) {

	window.location = "CadastroDisciplina?id=" + id;
}