import {
  getItemFromLocalStorage,
  setItemToLocalStorage,
} from "@/services/localStorageService";
import { ICart, ISetExtended } from "@/types";
import { create } from "zustand";

// export const useApplicationStore = create<{
//   cart: ICart;
//   addToCart: (id: string, quantity?: number) => void,
//   removeFromCart: (id: string, quantity?: number) => void;
// }>((set) => ({
//   cart: { count: 0, itemIds: [] as string[] },

//   addToCart: (id: string, quantity: number = 1) =>
//     set((state: { cart: ICart }) => {
//       const newState = {
//         cart: {
//           count: state.cart.count + quantity,
//           itemIds: [...state.cart.itemIds, id]
//         }
//       }

//       setItemToLocalStorage('count', JSON.stringify(newState));
//       return newState;
//     }),

//   removeFromCart: (id: string, quantity: number = 1) =>
//     set((state: { cart: ICart }) => {
//       const ids = state.cart.itemIds.filter((itemId) => itemId !== id);

//       const newState = { cart: { count: state.cart.count - quantity, itemIds: [...ids] } };

//       setItemToLocalStorage('count', JSON.stringify(newState));
//       return newState;
//     }),
// }));

const getCount = (): ICart => {
  const result = getItemFromLocalStorage('count');
  if(!result.isSuccess) return { count: 0, items: [] } as ICart;

  const cartJson = JSON.parse(result.data!);
  return cartJson.cart!;
}

export const useApplicationStore = create<{
  cart: ICart;
  addToCart: (newItem: ISetExtended, quantity?: number) => void;
  removeFromCart: (item: ISetExtended, quantity?: number) => void;
}>((set) => ({
  cart: getCount(),

  addToCart: (newItem: ISetExtended, quantity: number = 1) =>
    set((state: { cart: ICart}) => {
      const newState = {
        cart: {
          count: state.cart.count + quantity,
          items: [...state.cart.items, newItem],
        },
      };

      setItemToLocalStorage('count', JSON.stringify(newState));
      return newState;
    }),

  removeFromCart: (item: ISetExtended, quantity: number = 1) =>
    set((state: { cart: ICart }) => {
      const filteredItems = state.cart.items.filter(
        (x) => !(x.id === item.id && x.timeStamp === item.timeStamp)
      );

      const newState = {
        cart: { count: state.cart.count - quantity, items: [...filteredItems] },
      };

      setItemToLocalStorage('count', JSON.stringify(newState));
      return newState;
    }),
}));

interface IUser {
  username: string;
}

interface IAuthInfo {
  isAuthenticated: boolean;
  user?: IUser;
}

export const useAuthentication = create<{
  authInfo: IAuthInfo;
  login: (userName: string, password: string) => boolean;
  logout: () => void;
}>((set) => ({
  authInfo: { isAuthenticated: false, user: undefined },

  login: (userName: string, password: string) => {
    let isLoginSuccess = false;

    set((state: { authInfo: IAuthInfo }) => {
      if (state.authInfo.isAuthenticated) return state;

      const defaultUserName = "codecamp";
      const defaultPassword = "123";
      const isUserNamePasswordMatch =
        userName === defaultUserName && password === defaultPassword;

      if (isUserNamePasswordMatch) {
        const newState = {
          authInfo: {
            isAuthenticated: true,
            user: { username: defaultUserName },
          },
        };
        isLoginSuccess = true;
        return newState;
      }

      return { authInfo: { isAuthenticated: false, user: undefined } };
    });

    return isLoginSuccess ? true : false;
  },

  logout: () =>
    set((state: { authInfo: IAuthInfo }) => {
      if (!state.authInfo.isAuthenticated) return state;
      return { authInfo: { isAuthenticated: false, user: undefined } };
    }),
}));
