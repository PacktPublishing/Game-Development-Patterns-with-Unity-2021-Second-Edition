# Game Development Patterns with Unity 2021-Second Edition

<a href="https://www.packtpub.com/product/game-development-patterns-with-unity-2021-second-edition/9781800200814"><img src="https://static.packt-cdn.com/products/9781800200814/cover/smaller" alt="Game Development Patterns with Unity 2021" height="256px" align="right"></a>

This is the code repository for [Game Development Patterns with Unity 2021-Second Edition](https://www.packtpub.com/product/game-development-patterns-with-unity-2021-second-edition/9781800200814), published by Packt.

**Explore practical game development using industry design patterns and best practices in Unity and C#**

## What is this book about?
Unity has a particular coding model and architecture that requires knowledge of common software design patterns. This means that to be able to optimally code a game in Unity in the same way you do in other engines, you'll have to adapt to programming techniques including design patterns.

This book covers the following exciting features: 
* Structure your Unity code using industry-standard development patterns to make it look professional
* Identify the right patterns for implementing specific game mechanics or features
* Discover anti-patterns to avoid making common bad design choices
* Review practical OOP techniques and learn how they're used in the context of a Unity project
* Optimize your code using Unity's ECS

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/1800200811) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>


## Instructions and Navigations
All of the code is organized into folders. For example, Chapter05.

The code will look like the following:
```
using UnityEngine;

namespace Chapter.State
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController; 
        
        public void Handle(BikeController bikeController)
        {
            if (!_bikeController)
                _bikeController = bikeController;

            _bikeController.CurrentSpeed = 0;
        }
    }
}
```

**Following is what you need for this book:**
This book is for intermediate-level Unity game developers who are looking to figure out industry standards in building Unity games. The book assumes knowledge of the game engine and programming in the C# language. This book won't be suitable for you if you're only just starting your journey toward becoming a professional game programmer.

With the following software and hardware list you can run all code files present in the book (Chapter 1-16).

### Software and Hardware List

| Chapter  | Software required                   | OS required                        |
| -------- | ------------------------------------| -----------------------------------|
| 1-16       | Unity 2021.2.0                | Windows, Mac OS X, and Linux (Any) |



We also provide a PDF file that has color images of the screenshots/diagrams used in this book. [Click here to download it](https://static.packt-cdn.com/downloads/9781800200814_ColorImages.pdf).



### Related products <Other books you may enjoy>
* Unity 2020 Virtual Reality Projects [[Packt]](https://www.packtpub.com/product/unity-2020-virtual-reality-projects-third-edition/9781839217333) [[Amazon]](https://www.amazon.in/dp/1839217332)

* Unity 2020 Mobile Game Development [[Packt]](https://www.packtpub.com/product/unity-2020-mobile-game-development-second-edition/9781838987336) [[Amazon]](https://www.amazon.in/dp/1838987339)

## Get to Know the Author
**David Baron**
is a game developer with over 15 years of experience in the industry. He has worked for some of the top AAA, mobile, and indie game studios in Montreal, Canada. He has a skill set that includes programming, design, and 3D art. As a programmer, he has worked on a multitude of games for various platforms, including virtual reality, mobile, and consoles


## Other books by the author
* [Hands-On Game Development Patterns with Unity 2019](https://www.packtpub.com/product/hands-on-game-development-patterns-with-unity-2019/9781789349337)


