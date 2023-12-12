import { useAuthentication } from '@/stores/applicationStore';
import { Button, Form, Input } from 'antd';
import { useRouter } from 'next/router';
import React, { FunctionComponent } from 'react';

const InputComponent: FunctionComponent<{classNames: string[]}> = ({classNames}) => {
    const router = useRouter();
    const login = useAuthentication(state => state.login);
    const onFinishHandler = (values: AuthType) => {
        const isLoginSuccess = login(values.username!, values.password!);

        if(isLoginSuccess) router.push("/home");
    }

    interface AuthType {
        username?: string;
        password?: string;
    };

    return (
        <div className={`shadow-lg w-5/6 p-4 max-w-[800px] rounded-lg ${classNames.join(' ')}`}>
            <Form
                layout='vertical'
                labelCol={{span: 100}}
                wrapperCol={{span: 100}}
                onFinish={onFinishHandler}
            >
                <Form.Item<AuthType>
                    label='Username'
                    name='username'
                    rules={[{ required: true, message: 'Username is requried' }]}>
                    <Input type='text' placeholder='Pickachu' />
                </Form.Item>
                <Form.Item<AuthType>
                    label='Password'
                    name='password'
                    rules={[{ required: true, message: 'Password is requried' }]}>
                    <Input type='password'  placeholder='***' />
                </Form.Item>

                <Button type='primary' htmlType='submit' className='bg-blue-500'>Login</Button>
            </Form>
        </div>
    );
};

export default InputComponent;