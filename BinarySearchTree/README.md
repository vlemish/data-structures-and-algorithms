# BinarySearchTree
Binary search tree contains 8 methods to use the following data structure.
To try out the project you can:

![Example of downloading zip archive](BinarySearchTree/imgs/downloadZip.gif)
 or using git command prompt
 ```
 git-clone git@github.com:MdmaSteel/BinarySearchTree.git
 ```
 
 ![Example of downloading via command prompt](BinarySearchTree/imgs/downloadVIAGitClone.gif)
 
# Example
There are included tests that you can just run like below.

![Example of program working](BinarySearchTree/imgs/exampleOfProgramWorking.gif)

# Methods

## AddMethod

Add method allows you to put value to a binary tree.\
Also, there is a delegate that allows you to see what is happening on every step of adding. **In Tests that are turned on by default**
If you want to turn on details on your using of **BinarySearchTree** you should create a new method something that has return type void and takes string parameter.
```
public void SomeMethod(string someString)
{
	//where to print is up to you -_-
	//for example in console \---\
	Console.WriteLine(someString);
}
```

*For more details look at* [BinaryTree](BinarySearchTree/BinaryTree.cs) *class*

## FindNode Method

FindNode Method allows you to check is the binary tree contains the value you are looking for.

*For more details look at* [BinaryTree](BinarySearchTree/BinaryTree.cs) *class*

## Remove Method

Remove Method allows you to remove value from the binary tree.

*For more details look at* [BinaryTree](BinarySearchTree/BinaryTree.cs) *class*


## GetMaxValue Method

GetMaxValue method allows you to get the max value which binary tree contains.

*For more details look at* [BinaryTree](BinarySearchTree/BinaryTree.cs) *class*

## GetMinValue Method

GetMinValue method allows you to get the min value which binary tree contains.

*For more details look at* [BinaryTree](BinarySearchTree/BinaryTree.cs) *class*

## GetMaxLevel Method

GetMaxLevel method allows you to get the max value of a binary tree.
**Note that one level is a full node**

*For more details look at* [BinaryTree](BinarySearchTree/BinaryTree.cs) *class*

## Print Method

The print method allows you to print your created binary tree.\
There are two options to print.
```(if GetMaxLevel() > 7)``` -> will be printed horizontally.

![BinaryTree Horizontal Print](BinarySearchTree/imgs/binaryTreeExample.jpg)

Otherwise will be printed vertically.

![BinaryTree Vertical Print](BinarySearchTree/imgs/binaryTreeExample1.jpg).


*For more details look at* [BinaryTree](BinarySearchTree/BinaryTree.cs) *class*
