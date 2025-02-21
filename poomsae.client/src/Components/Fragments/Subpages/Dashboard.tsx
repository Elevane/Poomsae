import React, { useState } from 'react';
import { Card, Button, Row, Col, Typography, Input, Badge } from 'antd';
import { HeartOutlined, CommentOutlined, BellOutlined } from '@ant-design/icons';

const { Title, Text } = Typography;

interface Post {
    id: number;
    user: string;
    content: string;
    date: string;
    likes: number;
    comments: number;
}

const posts: Post[] = [
    {
        id: 1,
        user: 'John Doe',
        content: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
        date: '2025-02-11',
        likes: 15,
        comments: 5,
    },
    {
        id: 2,
        user: 'Jane Smith',
        content: 'Curabitur blandit tempus porttitor.',
        date: '2025-02-10',
        likes: 8,
        comments: 2,
    },
    {
        id: 3,
        user: 'Tom Jones',
        content: 'Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum.',
        date: '2025-02-09',
        likes: 25,
        comments: 10,
    },
];

// --- Section des actualités ---
interface News {
    id: number;
    title: string;
    description: string;
    date: string;
}

const news: News[] = [
    {
        id: 1,
        title: 'Breaking News: New Features Released!',
        description: 'Ant Design has released a new set of features including better performance and new components.',
        date: '2025-02-11',
    },
    {
        id: 2,
        title: 'Update on React 18 Release',
        description: 'React 18 introduces concurrent rendering and new hooks for a smoother user experience.',
        date: '2025-02-10',
    },
    {
        id: 3,
        title: 'React Conf 2025 - Upcoming Event',
        description: 'Join the React Conf 2025 to hear about new updates, features, and best practices for building modern React apps.',
        date: '2025-02-09',
    },
];

// --- Section des suggestions d'utilisateurs ---
interface User {
    id: number;
    name: string;
    description: string;
}

const users: User[] = [
    { id: 1, name: 'Alice', description: 'Active sur les discussions de React' },
    { id: 2, name: 'Bob', description: 'Développeur Python passionné' },
    { id: 3, name: 'Charlie', description: 'Écrivain de blogs tech' },
];

// --- Section des notifications ---
const NotificationBadge = () => (
    <Badge count={5} showZero>
        <Button style={{ marginLeft: '5px' }} shape="circle" icon={<BellOutlined />} />
    </Badge>
);

const DashBoard: React.FC = () => {
    const [likedPosts, setLikedPosts] = useState<number[]>([]);
    const [filteredPosts, setFilteredPosts] = useState<Post[]>(posts);
    const [filteredUsers, setFilteredUsers] = useState<User[]>(users);
    const [filteredNews, setFilteredNews] = useState<News[]>(news);
    const toggleLike = (postId: number): void => {
        setLikedPosts((prev) =>
            prev.includes(postId) ? prev.filter((id) => id !== postId) : [...prev, postId]
        );
    };
    const filterHubData = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (e.target.value) {
            console.log(e.target.value)
            setFilteredPosts(filteredPosts.filter((post) => post.content.includes(e.target.value) || post.user.includes(e.target.value) || post.date.includes(e.target.value)));
            setFilteredUsers(filteredUsers.filter((user) => user.name.includes(e.target.value) || user.description.includes(e.target.value)));
            setFilteredNews(filteredNews.filter((n) => n.title.includes(e.target.value) || n.description.includes(e.target.value) || n.date.includes(e.target.value)));
        }
        setFilteredNews(news)
        setFilteredPosts(posts)
        setFilteredUsers(users)
    }
    return (
        <div style={{ padding: '20px' }}>
            <Row gutter={16} >
                {/* Section de recherche */}
                <Col span={24}>
                    <Input.Search style={{ width: "50vh" }} onChange={filterHubData} placeholder="Rechercher des posts ou des utilisateurs" enterButton /> <NotificationBadge />
                </Col>
                {/* Section des posts */}
                <Col span={24}>
                    <Title level={3}>Posts</Title>
                    <Row gutter={16}>
                        {filteredPosts.map((post) => (
                            <Col span={8} key={post.id}>
                                <Card
                                    title={`Post by ${post.user}`}
                                    extra={<small>{post.date}</small>}
                                    hoverable
                                    style={{ marginBottom: '20px' }}
                                >
                                    <p>{post.content}</p>
                                    <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                                        <Button
                                            icon={<HeartOutlined />}
                                            type={likedPosts.includes(post.id) ? 'primary' : 'default'}
                                            onClick={() => toggleLike(post.id)}
                                        >
                                            {likedPosts.includes(post.id) ? `Liked (${post.likes + 1})` : `Like (${post.likes})`}
                                        </Button>
                                        <Button icon={<CommentOutlined />}>{`Comments (${post.comments})`}</Button>
                                    </div>
                                </Card>
                            </Col>
                        ))}
                    </Row>
                </Col>

                {/* Section des actualités */}
                <Col span={24}>
                    <Title level={3}>Fil d'Actualités</Title>
                    <Row gutter={16}>
                        {filteredNews.map((newsItem) => (
                            <Col span={8} key={newsItem.id}>
                                <Card
                                    title={newsItem.title}
                                    extra={<small>{newsItem.date}</small>}
                                    hoverable
                                    style={{ marginBottom: '20px' }}
                                >
                                    <p>{newsItem.description}</p>
                                </Card>
                            </Col>
                        ))}
                    </Row>
                </Col>

                {/* Section des suggestions d'utilisateurs */}
                <Col span={24}>
                    <Title level={3}>Suggestions d'Utilisateurs</Title>
                    <Row gutter={16}>
                        {filteredUsers.map((user) => (
                            <Col span={8} key={user.id}>
                                <Card
                                    title={user.name}
                                    extra={<Button>Suivre</Button>}
                                    hoverable
                                    style={{ marginBottom: '20px' }}
                                >
                                    <Text>{user.description}</Text>
                                </Card>
                            </Col>
                        ))}
                    </Row>
                </Col>

            </Row>
        </div>
    );
};

export default DashBoard;