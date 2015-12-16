def hello(req):
	return "hello world" + req["name"]


def test1(arg):
    class myclass:
        name=None
    mc = myclass()
    mc.name = arg.Path
    return mc.__dict__