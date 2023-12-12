import HeaderComponent from '@/components/HeaderComponent/HeaderComponent';
import { useApplicationStore } from '@/stores/applicationStore';
import { Flex, Row, Col } from 'antd';
import { ICart, ISetExtended } from '@/types';
import { useEffect, useState } from 'react';
import AntCard2Component from '@/components/CardComponent/AntCardComponent/AntCard2Component';

const Index = () => {
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
        <div>
            <HeaderComponent />
            <Flex justify='center' className='py-4'>
                <Row gutter={[10, 10]} className='wrapper'>
                    {
                        cart.items.map((item: ISetExtended, index: number) => <Col span={24} className='w-full' key={item.id + index}><AntCard2Component _item={{ ...item }} /></Col>)
                    }
                </Row>
            </Flex>
        </div>
    );
};

export default Index;