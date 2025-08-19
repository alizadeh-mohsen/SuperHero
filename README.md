# SuperHero

sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout api-cert.key -out api-cert.crt -config api-cert.conf -passin pass:Password@1
sudo openssl pkcs12 -export -out api-key.pfx -inkey api-cert.key -in api-cert.crt
sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout mvc-cert.key -out mvc-cert.crt -config mvc-cert.conf -passin pass:Password@1
sudo openssl pkcs12 -export -out mvc-key.pfx -inkey mvc-cert.key -in mvc-cert.crt

enbale kubernetes in docker
deploy the dashboard UI
  - install helm
  - run deploy dashboard commands
create service account
create admin user
add role
add token
https://localhost:8443/#/pod?namespace=default




winget nistall helm.helm
# Add kubernetes-dashboard repository
helm repo add kubernetes-dashboard https://kubernetes.github.io/dashboard/
# Deploy a Helm Release named "kubernetes-dashboard" using the kubernetes-dashboard chart
helm upgrade --install kubernetes-dashboard kubernetes-dashboard/kubernetes-dashboard --create-namespace --namespace kubernetes-dashboard

kubectl apply -f .\admin-user.yaml
kubectl apply .\admin-role.yaml

# [Deploy and Access the Kubernetes Dashboard - Source](https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/#deploying-the-dashboard-ui)

## 1. [Install Helm](https://helm.sh/docs/intro/install/)
The Helm community provides the ability to install Helm through operating system package managers. These are not supported by the Helm project and are not considered trusted 3rd parties.

## 2. [Deploy Dashboard](https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/#deploying-the-dashboard-ui)
```
# Add kubernetes-dashboard repository
helm repo add kubernetes-dashboard https://kubernetes.github.io/dashboard/
# Deploy a Helm Release named "kubernetes-dashboard" using the kubernetes-dashboard chart
helm upgrade --install kubernetes-dashboard kubernetes-dashboard/kubernetes-dashboard --create-namespace --namespace kubernetes-dashboard
```
## 3. [Setup Admin User](https://github.com/kubernetes/dashboard/blob/master/docs/user/access-control/creating-sample-user.md)
Create a Service Account with the name admin-user in namespace kubernetes-dashboard first. Copy these commands to a new manifest file called dashboard-adminuser.yaml and use **kubectl apply -f dashboard-adminuser.yaml** to apply.
```
apiVersion: v1
kind: ServiceAccount
metadata:
  name: admin-user
  namespace: kubernetes-dashboard
```
Next, setup the cluster role binding. Copy the following to a file and run the **kubectl apply -f FileNameHere.yml** command.
```
apiVersion: rbac.authorization.k8s.io/v1
kind: ClusterRoleBinding
metadata:
  name: admin-user
roleRef:
  apiGroup: rbac.authorization.k8s.io
  kind: ClusterRole
  name: cluster-admin
subjects:
- kind: ServiceAccount
  name: admin-user
  namespace: kubernetes-dashboard
```

## 4. [Get Bearer Token](https://github.com/kubernetes/dashboard/blob/master/docs/user/access-control/creating-sample-user.md#getting-a-bearer-token-for-serviceaccount)
Now we need to find the token we can use to log in. Execute the following command:
```
kubectl -n kubernetes-dashboard create token admin-user
```
## 5. Launch dashboard
Run the command:
```
kubectl -n kubernetes-dashboard port-forward svc/kubernetes-dashboard-kong-proxy 8443:443
```
Dashboard will be available at: https://localhost:8443
