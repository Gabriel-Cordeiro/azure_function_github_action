pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        dotnetClean()
        dotnetRestore()
        dotnetPublish(configuration: 'Release')
      }
    }

    stage('Tests') {
      steps {
        dotnetTest()
      }
    }

    stage('Publish Function') {
      steps {
        azureFunctionAppPublish(azureCredentialsId: 'AzureCredentials', resourceGroup: 'TestEventHub', appName: 'publisherNow', deployOnlyIfSuccessful: true, filePath: 'zure_function_github_action_main\\src\\Functions\\bin\\Release\\netcoreapp3.1\\')
      }
    }

  }
}