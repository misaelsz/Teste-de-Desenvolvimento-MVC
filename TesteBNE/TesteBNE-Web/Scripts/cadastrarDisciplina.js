
//document.write(unescape("%3Cscript src='Scripts/botaoExcluir.js' type='text/javascript'%3E%3C/script%3E"));
document.write(unescape("%3Cscript src='/Servicos/ajax.js' type='text/javascript'%3E%3C/script%3E"));
//document.write(unescape("%3Cscript src='/Scripts/excluir.js' type='text/javascript'%3E%3C/script%3E"));
$(document).ready(function () {
	var valor;
	var valorEscolhido;
	url = location.href;
	console.log(url);
	console.log("entrou aki");
	var parametroDaUrl = url.split("?")[1];

	// verifica se algum parametro foi passado pela url
	if (parametroDaUrl !== undefined) {

		console.log("dentro do if: " + parametroDaUrl);
		parametroDaUrl = parametroDaUrl.split("=")[1];
		console.log(parametroDaUrl);

		var id = parametroDaUrl;
		console.log("valor do id" + id)
		//faz a busca no banco de dados, buscando o objeto pelo id, o segundo parametro e uma funcao no caso estou chamando a funçao editar
		getDisciplinaPorId(id);

	}
	else {
		$("#bntCadDisciplina").click(function () {

			var Disciplina = cadastrarDisciplina();
			console.log("Objeto a ser inserido no banco :" + Disciplina)
			disciplina = JSON.parse(Disciplina);
			console.log("nome do cara: " + disciplina.Nome_Disciplina);
			console.log(disciplina);
			if (disciplina.Nome_Disciplina === "") {
				alert("campos obrigatórios não preenchidos");
			} else {
				Disciplina = JSON.stringify(disciplina);
				console.log("depois do metodo stringfy: " + Disciplina);
				postDisciplina(Disciplina);
			}
		});
	}
});

function cadastrarDisciplina() {
	var disciplina = JSON.stringify({
		Nome_Disciplina: $("#txtNomeDisciplina").val()


	});
	return disciplina;
};