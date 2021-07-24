
const addToCart = async (id) => {
        const response = await fetch(`/Product/Index/${id}`);
        const data = await response.json();
        if (data !== "NOT_FOUND") {
            let productIds = localStorage.getItem("productIds");
            if (!productIds) {
                productIds = `${id}`;
            } else {
                productIds += `,${id}`;
            }

            localStorage.setItem("productIds", productIds);
            fetchCart(data, 'plus');
        }
}

const fetchCart = async (data, type) => {
    const productIds = localStorage.getItem("productIds");
    let amount = localStorage.getItem("amount");
    if (data) {
        if (type === 'plus') {
            amount = Number(amount) + Number(data.price);
            localStorage.setItem("amount", amount);
        } else {
            amount = Number(amount) - Number(data.price);
            localStorage.setItem("amount", amount);
        }

    }

    if (amount) {
        document.getElementById("total-amount").innerText = `${localStorage.getItem("amount")} vnđ`;
    }

    const ids = productIds?.split(",");
    const response = await fetch(`/Product/List?ids=${ids?.toString()}`);
    const products = await response.json();
    if (products !== "NOT_FOUND") {
        document.getElementById("hdk-count").innerText = products.length;
    }
}

fetchCart();

