document.addEventListener("DOMContentLoaded", () => {
    const products = [
        { id: 1, name: "Laptop", description: "A high-performance laptop.", price: 1500.0, imageUrl: "/images/laptop.jpg" },
        { id: 2, name: "Smartphone", description: "A cutting-edge smartphone.", price: 800.0, imageUrl: "/images/phone.jpg" },
        { id: 3, name: "Headphones", description: "Noise-cancelling headphones.", price: 200.0, imageUrl: "/images/headphones.jpg" },
    ];

    const quickViewButtons = document.querySelectorAll(".btn-quick-view");
    const modalProductName = document.getElementById("modalProductName");
    const modalProductImage = document.getElementById("modalProductImage");
    const modalProductDescription = document.getElementById("modalProductDescription");
    const modalProductPrice = document.getElementById("modalProductPrice");

    quickViewButtons.forEach((button) => {
        button.addEventListener("click", (e) => {
            const productId = parseInt(button.getAttribute("data-id"));
            const product = products.find((p) => p.id === productId);

            if (product) {
                modalProductName.textContent = product.name;
                modalProductImage.src = product.imageUrl;
                modalProductDescription.textContent = product.description;
                modalProductPrice.textContent = `$${product.price.toFixed(2)}`;

                // Show modal
                const productModal = new bootstrap.Modal(document.getElementById("productModal"));
                productModal.show();
            }
        });
    });
});
