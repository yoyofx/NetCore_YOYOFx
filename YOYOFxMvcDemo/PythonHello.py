def hello(request):
	return "hello world" + request.QueryString["name"]
