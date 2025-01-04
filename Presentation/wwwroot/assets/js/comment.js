$(function () {
	$('#addComment').on("click", function (event) {
		event.preventDefault();

		const name = $("#commentName").val();
		const email = $("#commentEmail").val();
		const message = $("#comment").val();
		const newsId = $("#newsId").val();

		$.ajax({
			method: "POST",
			url: "/news/createcomment",
			contentType: "application/json",
			data: JSON.stringify({
				Name: name,
				Email: email,
				Message: message,
				NewsId: newsId
			}),
			success: function (response) {
				alert("Comment added")
				location.reload();
			},
			error: function (xhr) {
				alert(xhr.responseText)
			}
		})
	})
})