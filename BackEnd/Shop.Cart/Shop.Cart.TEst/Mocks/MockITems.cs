using System.Collections.Generic;
using Shop.Cart.Domain.Entities;
using Shop.Cart.Domain.Exception; // Import necessário

public static class MockITems
{
    public static  string MOCK_USER_ID = "user_12345"; 
    
    // --- 2. PRODUTOS MOCK ---
    public static Product NotebookGamer { get; } = new Product(
        name: "Notebook Gamer Xtreme 5000",
        price: 7999.99m,
        stock: 12,
        description: "Potência inigualável para jogos.",
        imageUrl: "https://mockserver.com/images/p101.jpg"
    ){Id = 1};

    public static Product TecladoMecanico { get; } = new Product(
        name: "Teclado Mecânico Pro RGB",
        price: 450.00m,
        stock: 55,
        description: "Switches táteis e RGB.",
        imageUrl: "https://mockserver.com/images/p205.jpg"
    ){Id = 2};

    public static Product MouseErgonomico { get; } = new Product(
        name: "Mouse Sem Fio Ergonômico Silent",
        price: 129.50m,
        stock: 200,
        description: "Design vertical para prevenir LER.",
        imageUrl: "https://mockserver.com/images/p310.jpg"
    ){Id = 3};


    // --- 3. ITENS DO CARRINHO MOCK (CartItem) ---

    public static CartItem NotebookItem { get; } = new CartItem(
        quantity: 3,
        product: NotebookGamer,
        userId: MOCK_USER_ID
    )
    {
        CartId =  1,
        Id = 1
    };
    
    public static CartItem MouseItem { get; } = new CartItem(
        quantity: 2,
        product: MouseErgonomico,
        userId: "user_12345"
    )
    {
        CartId = 1,
        Id = 2
    };
    
    public static CartItem TecladoItem { get; } = new CartItem(
        quantity: 3,
        product: TecladoMecanico,
        userId: MOCK_USER_ID
    )
    {
        CartId = 1 ,
        Id = 3
    };

    public static Cart CartMock { get; } = new ()
    {
        UserId = MOCK_USER_ID,
        Id = 1,
        // Garante que a lista Items seja preenchida na inicialização
        Items = new List<CartItem> 
        {
            NotebookItem,
            MouseItem,
            TecladoItem
        }
    };
    
    static MockITems()
    {
        NotebookItem.Cart = CartMock;
        MouseItem.Cart = CartMock;
        TecladoItem.Cart = CartMock;
    }
}