import { create } from "zustand";
import { persist } from "zustand/middleware";
import { fetchProducts } from "@/services/productService";
import { GetProductRequest } from "@/data/Requests";
import { ProductModel } from "@/data/ProductModel";

interface ProductStoreState {
    products: ProductModel[];
    hasHydrated: boolean;
    fetchProducts: (request?: GetProductRequest) => Promise<void>;
    setHasHydrated: (value: boolean) => void;
}

export const useProductStore = create<ProductStoreState>()(
    persist(
        (set) => ({
            products: [],
            hasHydrated: false,
            setHasHydrated: (value) => set({ hasHydrated: value }),
            lastFetched: null,


            fetchProducts: async (request) => {
                const result = await fetchProducts(request || {
                    id: -1,
                    name: '',
                    description: '',
                    barcode: '',
                    categoryId: -1,
                    subCategoryId: -1
                });
                set({ products: result });
            },
        }),
        {
            name: "product-storage",
            onRehydrateStorage: () => (state) => {
                state?.setHasHydrated(true);
            }
        }
    )
);
