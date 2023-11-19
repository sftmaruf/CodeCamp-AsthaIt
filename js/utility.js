function utility() {
    const getById = name => document.getElementById(name);
    const scrollToBottom = window => window.scrollTop = window.scrollHeight;

    const createTick = (color='#a1a5ad') => {
        const svg = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
        const path = document.createElementNS('http://www.w3.org/2000/svg', 'path');

        svg.setAttribute('data-message-status', 'sent');
        svg.setAttribute('id', 'message-status');
        svg.setAttribute('width', `15`);
        svg.setAttribute('height', `15`);
        svg.setAttribute('viewBox', `0 0 24 24`);
        svg.setAttribute('fill', `none`);

        path.setAttribute('d', 'M5 14L8.5 17.5L19 6.5');
        path.setAttribute('stroke', color);
        path.setAttribute('stroke-width', '1.5');
        path.setAttribute('stroke-linecap', 'round');
        path.setAttribute('stroke-linejoin', 'round');
        
        svg.setAttribute('style', `z-index: 1000; width: 15px; height: 15px; transform: translateY(-16px)`);
        svg.appendChild(path);
        return svg;
    }

    const createText = (
        text,
        bgColor,
        padding = '12px',
        borderRadius = '5px'
    ) => {
        const textContainer = document.createElement('p');
        const words = text.split(' ');

        let i = 0;
        const effect = setInterval(() => {
            textContainer.innerText += ` ${words[i++]}`;

            if (i == words.length)
            {
                scrollToBottom(getById('chat-view'));
                clearInterval(effect);
            }
        }, 40);

        textContainer.style.minHeight = '39px';
        textContainer.style.minWidth = '10px';
        textContainer.style.padding = padding;
        textContainer.style.backgroundColor = bgColor;
        textContainer.style.borderRadius = borderRadius;
        textContainer.style.marginTop = '5px';

        return textContainer;
    }

    const createProfilePicture = (picture, borderRadius = '50%') => {
        const img = document.createElement('img');
        img.src = picture;

        img.style.height = '25px';
        img.style.aspectRatio = 1;
        img.style.borderRadius = borderRadius

        return img;
    }

    const createContent = (name, text, options = { alignItems: 'start', bgColor: '#f6f6f6' }) => {
        const div = document.createElement('div');
        const p = document.createElement('p');
        
        p.innerText = name;
        div.append(p, createText(text, options.bgColor));

        div.style.display = 'flex';
        div.style.flexDirection = 'column';
        div.style.alignItems = options.alignItems;
        div.style.maxWidth = '70%';

        return div;
    }

    const createResponseMessage = (messageInfo) => {
        const { sender, text } = messageInfo;
        
        const message = document.createElement('div');
        const picture = createProfilePicture(sender.image);
        console.log(picture);
        const content = createContent(sender.name, text);
        
        picture.style.marginRight = '10px';
        message.append(picture, content);
        
        message.style.display = 'flex';
        message.style.padding = '10px';

        return message;
    }

    const createMessage = (messageInfo) => {
        const { sender, text } = messageInfo;

        const message = document.createElement('div');
        const picture = createProfilePicture(sender.image);
        console.log(picture);
        const content = createContent(sender.name, text, { alignItems: 'end', bgColor: '#fcf5f2' });

        message.style.display = 'flex';
        message.style.justifyContent = 'end';
        message.style.padding = '10px';
        picture.style.marginLeft = '10px';
        picture.classList.add('picture-message');
        
        content.appendChild(createTick());
        message.append(content, picture);

        return message;
    }

    const createTypingEffect = (name, label = "is typing") => {
        const p = document.createElement('p');
        const dot = document.createElement('span');
        dot.innerText = '.';
        
        p.classList.add('py-1');
        p.innerText = `${name} ${label}`;
        p.append(dot.cloneNode(true), dot.cloneNode(true), dot.cloneNode(true))

        return p;
    }

    const getMessageStatus = (message) => {
        if (message.hasChildNodes())
        {
            const first = message.firstChild;
            if (first.hasChildNodes())
            {
                for (let i = 0; i < first.children.length; i++)
                {
                    if (first.children[i].hasAttribute('data-message-status'))
                    {
                        return first.children[i].firstChild; 
                    }
                }
            }
        }
    }

    const makeMessageAsDelivered = (message) => {
        getMessageStatus(message).style.stroke = '#141B34';
    }

    const makeMessageAsRead = (message) => {
        getMessageStatus(message).style.stroke = 'green';
    }

    const hidePicture = (parent) => parent.lastChild.style.visibility = 'hidden';

    const appendMessage = (message) => {
        const chatView = document.getElementById('chat-view');
        chatView.appendChild(message);

        chatView.scrollTop = chatView.scrollHeight;
    }

    const renderTypingEffect = (typist) => {
        const textEffect = document.getElementById('typing-effect');
        const isCurrentlyTyping = textEffect.hasChildNodes();
        
        if (!isCurrentlyTyping) textEffect.appendChild(createTypingEffect(typist));
    }

    const removeTypingEffect = () => {
        const textEffect = document.getElementById('typing-effect');
        textEffect.firstChild.remove();
    }

    return {
        createResponseMessage,
        createMessage,
        appendMessage,
        makeMessageAsDelivered,
        makeMessageAsRead,
        renderTypingEffect,
        removeTypingEffect,
        hidePicture,
        getById
    }
};