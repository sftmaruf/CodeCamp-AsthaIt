import { FunctionComponent, useEffect, useState } from "react";
import { Button, Flex } from 'antd';
import { useApplicationStore, useAuthentication } from "@/stores/applicationStore";
import Link from "next/link";
import { useRouter } from "next/router";
import { getItemFromLocalStorage } from "@/services/localStorageService";
import { ICart } from "@/types";

const HeaderComponent: FunctionComponent = () => {
  const { isAuthenticated, user } = useAuthentication(state => state.authInfo);
  const logout = useAuthentication(state => state.logout);
  const router = useRouter();

  const [cart, setCart] = useState<ICart>({count: 0, items: []});
  const c = useApplicationStore(state => state.cart);
  useEffect(() => {
    setCart(c);
    // const result = getItemFromLocalStorage('count');
    // if(result.isSuccess) {
    //     const resultAsJson = JSON.parse(result.data!);
    //     setCart(resultAsJson.cart);
    // }
}, [c]);


  return (
    <Flex justify="center" align="center" className='h-[60px] bg-slate-50 shadow-md'>
      <Flex justify='space-between' className='wrapper px-4'>
      <Link href='/home' className='flex items-center text-black font-bold text-2xl'>Home</Link>
        <Flex align="center">
          <p className='mr-6'>{user?.username}</p>

          <Link href={'/cart'} className='relative mr-6'>
            <svg
              width="30"
              height="30"
              viewBox="0 0 24 24"
              fill="none"
              xmlns="http://www.w3.org/2000/svg">
              <path
                d="M2 22L1.25658 21.9009C1.22801 22.1152 1.2933 22.3314 1.43571 22.494C1.57813 22.6567 1.7838 22.75 2 22.75L2 22ZM22 22V22.75C22.2162 22.75 22.4219 22.6567 22.5643 22.494C22.7067 22.3314 22.772 22.1152 22.7434 21.9009L22 22ZM20 7L20.7434 6.90088L20.6566 6.25H20V7ZM4 7V6.25H3.34336L3.25658 6.90088L4 7ZM2 22.75H22V21.25H2V22.75ZM22.7434 21.9009L20.7434 6.90088L19.2566 7.09912L21.2566 22.0991L22.7434 21.9009ZM20 6.25H4V7.75H20V6.25ZM3.25658 6.90088L1.25658 21.9009L2.74342 22.0991L4.74342 7.09912L3.25658 6.90088Z"
                fill="#141B34"
              />
              <path
                d="M7.5 9.5L7.71501 5.98983C7.87559 3.74176 9.7462 2 12 2C14.2538 2 16.1244 3.74176 16.285 5.98983L16.5 9.5"
                stroke="#141B34"
                strokeWidth="1.5"
              />
            </svg>
            <Flex justify='center' align='center' className='absolute translate-x-[18px] translate-y-[-15px] rounded-full bg-red-500 w-[15px] h-[15px]'>
              <small className='text-[12px] text-white'>{cart.count}</small>
            </Flex>
          </Link>

          {
            !isAuthenticated
              ? <Button onClick={() => router.push('/login')} type='primary' className='bg-blue-500'>Login</Button>
              : <Button onClick={() => logout()} type='primary' danger>Logout</Button>
          }
        </Flex>
      </Flex>
    </Flex>
  );
};

export default HeaderComponent;
