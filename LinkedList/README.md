<h1>Linked List</h1>
<h2 name="SingleLinkedList">Single Linked List</h2>
<p style="text-indent:24px"><b>Single Linked List</b> -  is a data structure that contains nodes. 
Every node contains a link to the next node. Single Linked List has the Head node. 
Further thats node uses to each action with Linked List, so every action will start with a request to 
the Head node.</p>
<div name="SFirstAndLast">
<h3>First and Last Properties</h3>
<p>For further work with Single Linked List, we should create properties to get the first element of the 
Single Linked List and the last element of the Single Linked List.</p>
<p>To return the first element of the Single Linked List all what we have to do is just to return 
the Head element of the linked list, it means that it's not necessary to create that property but 
for more comfortable use it won't excess.</p>
<p>To return the last element of the Single Linked List we need iterate through the linked list till 
the next element isn't null, and return the last element which isn't null.</p>

```
                var temp = Head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                return temp;
```

</div>
<div name="SCount">
<h3>Count Property</h3>
<p>Property <b>Count</b> - returns the count of nodes in the current Linked List, 
the algorithm of finding the count of nodes in linked list next:</p>

```
                int count = 0;
                var temp = Head;
                while (temp != null)
                {
                    temp = temp.Next;
                    count++;
                }
```

<p>All that we have to do is to create "counter" and increment the counter until there are no elements in the Linked List.</p>
</div>
<div  name="SInsertFirst">
<h3>Insert First</h3>
<p>To insert a new node into the begining of the Linked List, we need to put as <b>Next</b> of inserted element current <b>Head</b> and declare as <b>Head</b> created node.<p>

```
            if (Head == null)
            {
                Head = new Node<T>(data);
                return;
            }

            var newNode = new Node<T>(data);
            newNode.Next = Head;
            Head = newNode;
```

</div>
<div name="SInsertLast">
<h3>Insert Last</h3>
<p>To insert a node in the end of the Linked List we can use created property <a href="#SFirstAndLast">Last</a> and as <b>Next</b> node of <a href="#SFirstAndLast">Last</a> node put the created node.</p>

```
            if (Head == null)
            {
                Head = new Node<T>(data);
                return;
            }

            var newNode = new Node<T>(data);
            Last.Next = newNode;
```

</div>
<div name="SInsertAfter">
<h3>Insert After</h3>
<p>Insert After Method takes two params: first - the node after which we should put the next node and second node - the node which we have to to the Linked List.
But, if node after which we have to put doesn't exist we throw a new exception</p>
<p>First of all, we have to find the node after which we have to put the new node. To find the node, we have to create two variables:
temp - contains current node, prev - contains previous node.</p>
<p>If the node after which we have to put the new node exists, we have to change in temp <b>Next</b> to created element and put as <b>Next</b> of the created node temp's <b>Next</b>.</p>

````

 var temp = Head;
            Node<T> prev = null;

            while (temp != null && temp.Data.CompareTo(after) !=0)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null)
            {
                throw new Exception($"There is no such an element: {element}");
            }

            if (temp.Data.CompareTo(after) == 0)
            {
                var tempNext = temp.Next;
                var newNode = new Node<T>(element);
                prev.Next.Next = newNode;
                newNode.Next = tempNext;
            }
````
</div>
<div name="SDelete node">
<h3>Delete node</h3>
<p>To delete a node from Linked List we need to find the node which we have to delete and delete references to the node.</p>
<p>So, the whole task is to find the node, create some variable to store previous node, and put as <b>Next</b> of the previous node the <b>Next</b> of a node we're deleting.<p>
</div>

```
  Node<T> temp = Head;
            Node<T> prev = null;

            if(temp!=null && temp.Data.CompareTo(key)==0)
            {
                Head = Head.Next;
                return;
            }

            while(temp!=null && temp.Data.CompareTo(key) != 0)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null)
            {
                return;
            }

            prev.Next = temp.Next;          
        }
```

<div name="SReverse Iterative">
<h3>Reverse Linked List Iterative</h3>
<p>To reverse Linked List iterative, we have to create variables: </p>
<ul>
<li>temp</li>
<li>current</li>
<li>prev</li>
</ul>
<p>The alghoritm of reverse Linked List presented below. <img src="https://github.com/vlemish/linkedList/blob/master/imgs/SingleListReverseExample.jpg"; alt="example"><p>

```
            Node<T> prev = null;
            Node<T> current = Head;
            Node<T> temp = null;

            while (current != null)
            {
                temp = current.Next;
                current.Next = prev;
                prev = current;
                current = temp;
            }

            Head = prev;
        }
```

</div>
<div name="SReverse Recursively">
<h3>Reverse Linked List Recursively</h3>
<p>To recursively reverse Linked the List we have to call the <b>Reverse</b> method until the current node isn't a null or <b>node.Next</b> isn't null. As a new param of the <b>Reverse</b> method we have to put node.<b>Next</b>
if we finally find the next node, we have just to return it. And if this isn't the last node, we have to put as <b>Next</b> node of the <b>Next</b> node of current node current node
and declare node.<b>Next</b> is null.</br>
For example, we have Linked List <1->2->3->4> we need to reverse it.</br>
We'll call Reverse until we got 4 and then just return it.</br>
So, now we have 3, and we declare that <b>3.Next.Next</b> will be 3, and <b>3.Next</b> is a null, which means that now we have next Linked List <4->3>.</br>
Then, we'll have 2, and we declare that <b>2.Next.Next</b> will be 2, so we'll have <4->3->2>.</br>
And the last node is 1, so <b>1.Next.Next</b> will be 1, and the final Linked List will be <4->3->2->1></p>
</div>
<p><img src="https://github.com/vlemish/linkedList/blob/master/imgs/exampleOutputSingleLinkedList.jpg"; alt="example of single linked list output "></p>
<p>For more details of my implementation of Double Linked List look at <a href="https://github.com/vlemish/linkedList/blob/master/SingleLinkedList/SingleLinkedList.cs">code</a>.</p>

<div>
<h2 name ="DoubleLinkedList">Double Linked List</h2>
<p><b>Doubly Linked List</b> is much the same to <a href="#SingleLinkedList">Single Linked List</a>. There is one difference, DoubleLinkedList has except reference to the next node, reference to the previous node. So, all we have to do is to take care of the previuos node. </br>
For example, the reverse of Double Linked List, we'll look like:</p>
<p><img src="https://github.com/vlemish/linkedList/blob/master/imgs/exampleOutputDoubleLinkedList.jpg"; alt="example of double linked list output"></p>
<p>For more details of my implementation of Doubly Linked List look at code <a href="https://github.com/vlemish/linkedList/blob/master/DoubleLinkedList/DoubleLinkedList.cs">code</a>.</p>
</div>