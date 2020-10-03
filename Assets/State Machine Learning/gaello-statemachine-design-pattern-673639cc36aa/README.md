# Welcome!

I assume that you are looking for some information about State Machine for Unity.
So I would like to say that you are in the right place!
I've made the post on my blog describing this design pattern. You can find my post here: https://www.patrykgalach.com/2019/03/18/design-pattern-state-machine/

Enjoy!

---

# How to use it?

This repository contains an example of how you can implement State Machine in Unity.

If you want to see that implementation of it, go straight to [Assets/Scripts/](https://bitbucket.org/gaello/statemachine-design-pattern/src/master/Assets/Scripts/) folder. You will find there [StateMachine.cs](https://bitbucket.org/gaello/statemachine-design-pattern/src/master/Assets/Scripts/StateMachine.cs) which is the core of this pattern.
But how can State Machine function without states? 😅
They are hidden just one more folder further in  [Assets/Scripts/States/](https://bitbucket.org/gaello/statemachine-design-pattern/src/master/Assets/Scripts/States/). [BaseState.cs](https://bitbucket.org/gaello/statemachine-design-pattern/src/master/Assets/Scripts/States/BaseState.cs) basically contain only virtual methods that I'm later overriding with [WaitState.cs](https://bitbucket.org/gaello/statemachine-design-pattern/src/master/Assets/Scripts/States/WaitState.cs) and [MoveState.cs](https://bitbucket.org/gaello/statemachine-design-pattern/src/master/Assets/Scripts/States/MoveState.cs).

And that's basically it!

---

#Well done!

You have just learned how to implement State Machine in Unity! 

##Congratulations!

For more visit my blog: https://www.patrykgalach.com