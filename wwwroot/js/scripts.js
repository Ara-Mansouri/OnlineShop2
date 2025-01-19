document.addEventListener("DOMContentLoaded", () => {
    const products = [
        { id: 1, name: "Laptop", description: "لپ‌تاپ اقتصادی و کاربردی", price: 45450000, imageUrl: "/images/products/vivabook.jpg" },
        { id: 2, name: "MacBook Pro", description: "Apple's flagship laptop.", price: 2000.0, imageUrl: "/images/products/macbook-pro.jpg" }
    ];

    const quickViewButtons = document.querySelectorAll(".btn-quick-view");
    const modalProductName = document.getElementById("modalProductName");
    const modalProductImage = document.getElementById("modalProductImage");
    const modalProductDescription = document.getElementById("modalProductDescription");
    const modalProductPrice = document.getElementById("modalProductPrice");
    const modalAddToCartBtn = document.getElementById("modalAddToCartBtn");

    quickViewButtons.forEach((button) => {
        button.addEventListener("click", () => {
            const productId = parseInt(button.getAttribute("data-id"));
            const product = products.find((p) => p.id === productId);

            if (product) {
                // Update modal content
                modalProductName.textContent = product.name;
                modalProductImage.src = product.imageUrl;
                modalProductDescription.textContent = product.description;
                modalProductPrice.textContent = `${product.price} تومان`;

                // Update "Add to Cart" button with product details
                modalAddToCartBtn.setAttribute("data-id", product.id);
                modalAddToCartBtn.setAttribute("data-name", product.name);
                modalAddToCartBtn.setAttribute("data-price", product.price);
                modalAddToCartBtn.setAttribute("data-image", product.imageUrl);

                // Show the modal
                const productModal = new bootstrap.Modal(document.getElementById("productModal"));
                productModal.show();
            }
        });
    });

    // Handle Add to Cart from modal
    modalAddToCartBtn.addEventListener("click", () => {
        const productId = modalAddToCartBtn.getAttribute("data-id");
        const productName = modalAddToCartBtn.getAttribute("data-name");
        const productPrice = modalAddToCartBtn.getAttribute("data-price");
        const productImage = modalAddToCartBtn.getAttribute("data-image");

        fetch(`/ShoppingCart/AddToCart?productId=${productId}&productName=${productName}&price=${productPrice}&imageUrl=${productImage}`, {
            method: "GET"
        })
            .then((response) => {
                if (response.ok) {
                    alert("Product added to cart successfully!");
                } else {
                    alert("Failed to add product to cart.");
                }
            })
            .catch((error) => {
                console.error("Error adding to cart:", error);
                alert("An error occurred while adding the product to the cart.");
            });
    });
});
