import React from "react";
import { Card, Divider, Space } from "antd";
import { Content } from "antd/es/layout/layout";
import ResetPasswordForm from "../Fragments/Forms/ResetAccountForm";
import DeleteAccountForm from "../Fragments/Forms/DeleteAccountForm";
import Footer from "../Fragments/Generic/Footer";
import PageBase from "./Generic/PageBase";

const Account: React.FC = () => {
    return (
        <PageBase>
            <Content style={{ padding: '24px', maxWidth: '1200px', margin: 'auto' }}>
                <Space direction="vertical" style={{ width: '100%' }}>
                    <Card title="Data & Account management" bordered={false}>
                        <DeleteAccountForm /></Card>
                    <Divider />
                    <Card title="Reset password" bordered={false}>
                        <ResetPasswordForm />
                    </Card>
                </Space>
            </Content>
            <Footer />
        </PageBase>
    );
};

export default Account;