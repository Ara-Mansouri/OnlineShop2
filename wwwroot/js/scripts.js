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

    quickViewButtons.forEach((button) => {
        button.addEventListener("click", () => {
            const productId = parseInt(button.getAttribute("data-id"));
            const product = products.find((p) => p.id === productId);

            if (product) {
                modalProductName.textContent = product.name;
                modalProductImage.src = product.imageUrl;
                modalProductDescription.textContent = product.description;
                modalProductPrice.textContent = product.price+" تومان ";

                const productModal = new bootstrap.Modal(document.getElementById("productModal"));
                productModal.show();
            }
        });
    });
});
