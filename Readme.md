# Artificial Intelligence

### Machine Learning

- `Unsupervised` - Human can train them with multiple data, and it will give response based on the patterns without Human intervention.
  > Eg, we are trained them with all versions and prices of IPhone, then it will predict the new version's Price.
- `Supervised` - Human can train them with vast number of data, and it will give response as human asked in a specific way.
  > Eg, We have trained them with data of forests, kids and balls. If we asked about create image with a Kid is playing a ball in Forest. Then it will give one output with that.

### Narrow Artificial Intelligence

- Give only a specified response to user
  > Google Assistant, Siri, Cortona

### Natural Language Processing (NLP)

- Naturally AI will analyze the data, and do the response immediately.
  > Translation, Sentiment Analysis, Question Answer.

## Artificial Intelligence Workloads and Considerations

1. Prediction and Demand Forecasting
   ![Prediction and Demand Forecasting](https://github.com/user-attachments/assets/aea600f6-d6d2-4749-bcaf-eeb9697e0fb2)
2. Anomaly Detection
   ![Anomaly Detection](https://github.com/user-attachments/assets/8ab89ca4-ff5e-42cb-9676-91331d198b36)
3. Computer Vision
   ![Computer](https://github.com/user-attachments/assets/173273a8-8770-4b95-8131-b9495b287e4d)
4. Natural Language Processing

- Regular things such as What time we are closing today? => Model will track the usual work timings, and it will tell us the average opening or close timins. Break timings.

# Agentic AI with Azure

![Quick Picture](https://github.com/user-attachments/assets/eabd0bc9-d97e-4d2c-a837-4f0bbbe954bd)

### LLM (Large Language Model)

- `LLM` is built by **Neural Network Architecture**. Which accepts some input parameter and analyze all the **differenct aspects** of it at the Hidden Layer and produces the output.
- `Foundation Model` is the specific instance or version of the LLM. Eg, GPT-3, GPT-4, Codex.

![LLM](https://github.com/user-attachments/assets/9c9bf807-bff8-49b7-9a28-21bacf1ae043)

- Initially LLMs are respond to the user based on its **trained data set**.
- Then developers have added `tools chain` with the LLM to increase its capabilities. That is **RAG(Retrieval Augmented Generation)** - which allows LLM to generate Tickets or send emails with the help of tools.
- Then AI Agents came into the picture, it will understand the problems in the prompts and **dynamically decide which tool to use** (we are giving full freedom to it) and generate the response for us.

![AI Agent](https://github.com/user-attachments/assets/59304421-5fae-438f-a894-0152bbe7cde4)

## Creation of Azure Open AI Resource

- Just create a Azure Open AI Resource with **S0 price tier**.
- After open it, click the Microsoft Foundry Panel.
- In the panel, we have to create a Deployment Model (Chat Completion Model).
- I have created GPT-4.1-nano - capability is 120K tokens, standard type.
- After deploying it, we have to chat with it, through Chat window.
- First we have to specify the **System Prompt**. Then in our upcoming prompt, our LLM will give the answer based on the System Prompt's context.
- It will have some input Parameters also. `Temperature` (range is 0 - 1), if mininum value has been set, then our LLM will give the more **accurate outputs**, if we set the maximum value, it will give the more **creative outputs**.

## Microsoft Foundry

- There are two types of Foundry projects

1. Standalone Foundry Project
2. AI-Hub based Foundry project

- Hub based project is the old one(Classic approach), Where we can share multiple projects across the team. Applicable for the organization level (Hierarchy based).
  > In portal, Switch button isn't enabled.
- Whereas, Standalone project(new approach) is for the individual one, which is applicable for the simple projects for a specific purpose.
  > In portal, Switch button is enabled.

#### While creating the AI-Hub, we got created AI services which enabled Multi-Model nature for out projects (Not only the Text as the input, we can give Speech, Image or Document), which is including some extra capabilities for out model.

### Azure AI Studio Architecture (Hub based Foundry Project)

![AI Studio Architecture](https://github.com/user-attachments/assets/7780c6a6-7ccd-4d01-8f5b-621082fc9a6e)

1. AI Hub
2. Projects
3. Management Centre - If we create Management center at the Hub level, then all the projects or services created under it, will share it.
4. AI services
5. AI Capabilities - Multimodel in nature
6. Storage - While creating AI Hub, Storage and Keyvault are generating within that resource. Storage account caputes the logs and helps for troubleshooting.
7. Key Vault - Manages the secret keys for Management centre.
