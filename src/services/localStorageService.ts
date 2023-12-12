import { Result } from "@/types";

const getLocalStorage = (): { localStorage?: Storage } => {
    if (typeof window !== "undefined" && window.localStorage) {
        return { localStorage: localStorage };
    }

    return { localStorage: undefined };
}

export const setItemToLocalStorage = (key: string, value: string) => {
    const { localStorage } = getLocalStorage();
    if(localStorage) localStorage.setItem(key, value);
}

export const getItemFromLocalStorage = (key: string): Result<string> => {
    const { localStorage } = getLocalStorage();

    if(localStorage) {
        const item = localStorage.getItem(key);
        if(item) return { isSuccess: true, data: item, errors: []};
    }

    return  { isSuccess: false, data: undefined, errors: []};
}