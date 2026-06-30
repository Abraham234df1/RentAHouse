import React, { useState } from 'react';
import { 
  Building2, 
  Home, 
  Search, 
  Plus, 
  Settings, 
  LogOut, 
  MapPin, 
  BedDouble, 
  Bath, 
  CheckCircle2, 
  XCircle,
  MoreVertical,
  Edit,
  Trash2,
  ChevronRight,
  Menu,
  X,
  AlertCircle
} from 'lucide-react';
import classNames from 'classnames';

// --- MOCK DATA ---
const mockApartments = [
  {
    id: 1,
    title: 'Penthouse Vista Panorámica',
    address: 'Av. Paseo de la Reforma 222',
    colonia: 'Juárez',
    city: 'Ciudad de México',
    rooms: 3,
    bathrooms: 2.5,
    price: 45000,
    status: 'Disponible',
    image: 'https://images.unsplash.com/photo-1512918728675-ed5a9ecdebfd?auto=format&fit=crop&w=800&q=80',
    description: 'Espectacular penthouse con vistas a toda la ciudad. Acabados de lujo, seguridad 24/7 y amenidades premium.'
  },
  {
    id: 2,
    title: 'Loft Moderno en Polanco',
    address: 'Aristóteles 123',
    colonia: 'Polanco',
    city: 'Ciudad de México',
    rooms: 1,
    bathrooms: 1,
    price: 28000,
    status: 'Ocupado',
    image: 'https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?auto=format&fit=crop&w=800&q=80',
    description: 'Increíble loft ideal para ejecutivos. A pasos de los mejores restaurantes y parques de la zona.'
  },
  {
    id: 3,
    title: 'Departamento Familiar Norte',
    address: 'Av. Universidad 1800',
    colonia: 'Coyoacán',
    city: 'Ciudad de México',
    rooms: 3,
    bathrooms: 2,
    price: 18500,
    status: 'Disponible',
    image: 'https://images.unsplash.com/photo-1502672260266-1c1c24240f38?auto=format&fit=crop&w=800&q=80',
    description: 'Espacioso departamento en zona sur, cerca de escuelas y centros comerciales. Ideal para familias.'
  },
  {
    id: 4,
    title: 'Estudio Centro Histórico',
    address: 'Madero 45',
    colonia: 'Centro Histórico',
    city: 'Ciudad de México',
    rooms: 1,
    bathrooms: 1,
    price: 12000,
    status: 'Mantenimiento',
    image: 'https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?auto=format&fit=crop&w=800&q=80',
    description: 'Pequeño estudio remodelado en el corazón de la ciudad. Perfecto para estudiantes o jóvenes profesionales.'
  },
  {
    id: 5,
    title: 'Condominio Lujo Santa Fe',
    address: 'Vasco de Quiroga 3800',
    colonia: 'Santa Fe',
    city: 'Ciudad de México',
    rooms: 2,
    bathrooms: 2,
    price: 32000,
    status: 'Disponible',
    image: 'https://images.unsplash.com/photo-1564013799919-ab600027ffc6?auto=format&fit=crop&w=800&q=80',
    description: 'Moderno condominio cerca de zona corporativa. Cuenta con gimnasio, alberca y salón de usos múltiples.'
  }
];

// --- COMPONENTS ---

// Navbar Component
const Navbar = ({ activeTab, setActiveTab }) => {
  const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);

  const navItems = [
    { id: 'home', label: 'Inicio', icon: <Home size={18} /> },
    { id: 'list', label: 'Departamentos', icon: <Building2 size={18} /> },
    { id: 'available', label: 'Disponibles', icon: <CheckCircle2 size={18} /> },
    { id: 'search', label: 'Buscar', icon: <Search size={18} /> },
  ];

  return (
    <header className="bg-white border-b border-slate-200 sticky top-0 z-50">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between h-16">
          <div className="flex items-center">
            <div className="flex-shrink-0 flex items-center gap-2 cursor-pointer" onClick={() => setActiveTab('home')}>
              <div className="w-8 h-8 bg-blue-900 rounded flex items-center justify-center text-white">
                <Building2 size={20} />
              </div>
              <span className="font-bold text-xl text-slate-900 tracking-tight">RealEstate<span className="text-blue-900">Pro</span></span>
            </div>
            <nav className="hidden md:ml-10 md:flex md:space-x-8">
              {navItems.map(item => (
                <button
                  key={item.id}
                  onClick={() => setActiveTab(item.id)}
                  className={classNames(
                    "inline-flex items-center gap-2 px-1 pt-1 border-b-2 text-sm font-medium transition-colors h-16",
                    activeTab === item.id 
                      ? "border-blue-900 text-blue-900" 
                      : "border-transparent text-slate-500 hover:border-slate-300 hover:text-slate-700"
                  )}
                >
                  {item.icon}
                  {item.label}
                </button>
              ))}
            </nav>
          </div>
          <div className="hidden md:flex items-center space-x-4">
            <button 
              onClick={() => setActiveTab('create')}
              className="inline-flex items-center gap-2 px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-blue-900 hover:bg-blue-800 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-900 transition-colors"
            >
              <Plus size={16} />
              Nuevo
            </button>
            <div className="w-8 h-8 rounded-full bg-slate-200 flex items-center justify-center text-slate-600 font-medium">
              AD
            </div>
          </div>
          <div className="flex items-center md:hidden">
            <button
              onClick={() => setIsMobileMenuOpen(!isMobileMenuOpen)}
              className="inline-flex items-center justify-center p-2 rounded-md text-slate-400 hover:text-slate-500 hover:bg-slate-100 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-blue-900"
            >
              {isMobileMenuOpen ? <X size={24} /> : <Menu size={24} />}
            </button>
          </div>
        </div>
      </div>

      {/* Mobile menu */}
      {isMobileMenuOpen && (
        <div className="md:hidden border-t border-slate-200 bg-white">
          <div className="pt-2 pb-3 space-y-1">
            {navItems.map(item => (
              <button
                key={item.id}
                onClick={() => {
                  setActiveTab(item.id);
                  setIsMobileMenuOpen(false);
                }}
                className={classNames(
                  "flex items-center gap-3 w-full pl-3 pr-4 py-3 border-l-4 text-base font-medium",
                  activeTab === item.id
                    ? "bg-blue-50 border-blue-900 text-blue-900"
                    : "border-transparent text-slate-600 hover:bg-slate-50 hover:border-slate-300 hover:text-slate-800"
                )}
              >
                {item.icon}
                {item.label}
              </button>
            ))}
            <button
              onClick={() => {
                setActiveTab('create');
                setIsMobileMenuOpen(false);
              }}
              className="flex items-center gap-3 w-full pl-3 pr-4 py-3 border-l-4 border-transparent text-base font-medium text-blue-900 hover:bg-slate-50"
            >
              <Plus size={18} />
              Nuevo Departamento
            </button>
          </div>
        </div>
      )}
    </header>
  );
};

// Footer Component
const Footer = () => (
  <footer className="bg-white border-t border-slate-200 mt-auto">
    <div className="max-w-7xl mx-auto py-8 px-4 sm:px-6 lg:px-8">
      <div className="md:flex md:items-center md:justify-between">
        <div className="flex justify-center space-x-6 md:order-2 text-sm text-slate-500">
          <a href="#" className="hover:text-slate-900">Soporte</a>
          <a href="#" className="hover:text-slate-900">Privacidad</a>
          <a href="#" className="hover:text-slate-900">Términos</a>
        </div>
        <div className="mt-8 md:mt-0 md:order-1">
          <p className="text-center text-sm text-slate-500">
            &copy; {new Date().getFullYear()} RealEstatePro. Todos los derechos reservados.
          </p>
        </div>
      </div>
    </div>
  </footer>
);

// Format currency
const formatPrice = (price) => {
  return new Intl.NumberFormat('es-MX', {
    style: 'currency',
    currency: 'MXN',
    maximumFractionDigits: 0
  }).format(price);
};

// Status Badge Component
const StatusBadge = ({ status }) => {
  const getStatusStyles = () => {
    switch (status.toLowerCase()) {
      case 'disponible':
        return 'bg-green-100 text-green-800 border-green-200';
      case 'ocupado':
        return 'bg-slate-100 text-slate-800 border-slate-200';
      case 'mantenimiento':
        return 'bg-amber-100 text-amber-800 border-amber-200';
      default:
        return 'bg-slate-100 text-slate-800 border-slate-200';
    }
  };

  return (
    <span className={classNames(
      "inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium border",
      getStatusStyles()
    )}>
      {status}
    </span>
  );
};

// Apartment Card Component
const ApartmentCard = ({ apt, onView, onEdit, onDelete }) => (
  <div className="bg-white rounded-xl shadow-sm border border-slate-200 overflow-hidden hover:shadow-md transition-shadow group flex flex-col">
    <div className="relative h-48 overflow-hidden bg-slate-100">
      <img 
        src={apt.image} 
        alt={apt.title} 
        className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500"
      />
      <div className="absolute top-3 right-3">
        <StatusBadge status={apt.status} />
      </div>
    </div>
    <div className="p-5 flex-1 flex flex-col">
      <div className="flex justify-between items-start mb-2">
        <h3 className="text-lg font-bold text-slate-900 line-clamp-1" title={apt.title}>{apt.title}</h3>
      </div>
      <p className="text-2xl font-bold text-blue-900 mb-4">{formatPrice(apt.price)}<span className="text-sm font-normal text-slate-500">/mes</span></p>
      
      <div className="space-y-2 mb-4 mt-auto">
        <div className="flex items-center text-sm text-slate-600">
          <MapPin size={16} className="mr-2 text-slate-400 flex-shrink-0" />
          <span className="truncate">{apt.colonia}, {apt.city}</span>
        </div>
        <div className="flex items-center gap-4 text-sm text-slate-600">
          <div className="flex items-center">
            <BedDouble size={16} className="mr-1.5 text-slate-400" />
            <span>{apt.rooms} habs.</span>
          </div>
          <div className="flex items-center">
            <Bath size={16} className="mr-1.5 text-slate-400" />
            <span>{apt.bathrooms} baños</span>
          </div>
        </div>
      </div>
      
      <div className="pt-4 border-t border-slate-100 flex gap-2">
        <button 
          onClick={() => onView(apt)}
          className="flex-1 bg-white border border-slate-300 text-slate-700 py-2 px-4 rounded-md text-sm font-medium hover:bg-slate-50 transition-colors"
        >
          Ver Detalle
        </button>
        <div className="relative group/menu">
          <button className="p-2 border border-slate-300 rounded-md text-slate-500 hover:bg-slate-50 hover:text-slate-700 transition-colors">
            <MoreVertical size={16} />
          </button>
          <div className="absolute right-0 bottom-full mb-1 w-36 bg-white border border-slate-200 rounded-md shadow-lg opacity-0 invisible group-hover/menu:opacity-100 group-hover/menu:visible transition-all z-10">
            <div className="py-1">
              <button 
                onClick={() => onEdit(apt)}
                className="w-full text-left px-4 py-2 text-sm text-slate-700 hover:bg-slate-50 flex items-center gap-2"
              >
                <Edit size={14} /> Editar
              </button>
              <button 
                onClick={() => onDelete(apt)}
                className="w-full text-left px-4 py-2 text-sm text-red-600 hover:bg-red-50 flex items-center gap-2"
              >
                <Trash2 size={14} /> Eliminar
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
);

// --- VIEWS ---

// 1. Home View
const HomeView = ({ setActiveTab }) => (
  <div className="animate-in fade-in duration-500">
    <div className="bg-slate-900 rounded-2xl overflow-hidden relative mb-12">
      <div className="absolute inset-0">
        <img 
          src="https://images.unsplash.com/photo-1600596542815-ffad4c1539a9?auto=format&fit=crop&w=2000&q=80" 
          alt="Modern architecture" 
          className="w-full h-full object-cover opacity-40"
        />
        <div className="absolute inset-0 bg-gradient-to-r from-slate-900 via-slate-900/80 to-transparent"></div>
      </div>
      <div className="relative z-10 py-16 md:py-24 px-6 md:px-12 max-w-3xl">
        <h1 className="text-4xl md:text-5xl font-bold text-white mb-6 leading-tight">
          Administración de rentas más inteligente y profesional
        </h1>
        <p className="text-lg md:text-xl text-slate-300 mb-8 max-w-2xl">
          Gestiona tu portafolio de departamentos, monitorea la disponibilidad y agiliza tus procesos inmobiliarios en una sola plataforma.
        </p>
        <div className="flex flex-wrap gap-4">
          <button 
            onClick={() => setActiveTab('list')}
            className="bg-blue-600 text-white px-6 py-3 rounded-lg font-medium hover:bg-blue-700 transition-colors shadow-sm"
          >
            Ver Propiedades
          </button>
          <button 
            onClick={() => setActiveTab('create')}
            className="bg-white/10 text-white backdrop-blur-sm border border-white/20 px-6 py-3 rounded-lg font-medium hover:bg-white/20 transition-colors"
          >
            Añadir Nuevo
          </button>
        </div>
      </div>
    </div>

    <div className="mb-8 flex justify-between items-end">
      <div>
        <h2 className="text-2xl font-bold text-slate-900">Resumen Rápido</h2>
        <p className="text-slate-500">Estado actual de tu portafolio</p>
      </div>
    </div>

    <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-12">
      <div className="bg-white p-6 rounded-xl shadow-sm border border-slate-200">
        <div className="w-12 h-12 bg-blue-50 rounded-lg flex items-center justify-center text-blue-900 mb-4">
          <Building2 size={24} />
        </div>
        <h3 className="text-3xl font-bold text-slate-900 mb-1">{mockApartments.length}</h3>
        <p className="text-slate-500 font-medium">Propiedades Totales</p>
      </div>
      <div className="bg-white p-6 rounded-xl shadow-sm border border-slate-200 cursor-pointer hover:border-green-300 hover:shadow-md transition-all" onClick={() => setActiveTab('available')}>
        <div className="w-12 h-12 bg-green-50 rounded-lg flex items-center justify-center text-green-600 mb-4">
          <CheckCircle2 size={24} />
        </div>
        <h3 className="text-3xl font-bold text-slate-900 mb-1">
          {mockApartments.filter(a => a.status === 'Disponible').length}
        </h3>
        <p className="text-slate-500 font-medium">Disponibles Ahora</p>
      </div>
      <div className="bg-white p-6 rounded-xl shadow-sm border border-slate-200">
        <div className="w-12 h-12 bg-amber-50 rounded-lg flex items-center justify-center text-amber-600 mb-4">
          <Settings size={24} />
        </div>
        <h3 className="text-3xl font-bold text-slate-900 mb-1">
          {mockApartments.filter(a => a.status === 'Mantenimiento').length}
        </h3>
        <p className="text-slate-500 font-medium">En Mantenimiento</p>
      </div>
    </div>
  </div>
);

// 2. List View (Departamentos)
const ListView = ({ title, subtitle, filterFn, onView, onEdit, onDelete, onSearch }) => {
  const filteredApartments = filterFn ? mockApartments.filter(filterFn) : mockApartments;

  return (
    <div className="animate-in fade-in duration-300">
      <div className="sm:flex sm:items-center sm:justify-between mb-8">
        <div>
          <h1 className="text-2xl font-bold text-slate-900">{title || 'Todos los Departamentos'}</h1>
          <p className="mt-1 text-sm text-slate-500">
            {subtitle || 'Gestiona y administra tu catálogo completo de propiedades.'}
          </p>
        </div>
        <div className="mt-4 sm:mt-0 flex gap-3">
          {onSearch && (
            <button 
              onClick={onSearch}
              className="inline-flex items-center justify-center px-4 py-2 border border-slate-300 shadow-sm text-sm font-medium rounded-md text-slate-700 bg-white hover:bg-slate-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-900"
            >
              <Search size={16} className="mr-2" />
              Filtrar
            </button>
          )}
        </div>
      </div>

      {filteredApartments.length > 0 ? (
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
          {filteredApartments.map(apt => (
            <ApartmentCard 
              key={apt.id} 
              apt={apt} 
              onView={onView}
              onEdit={onEdit}
              onDelete={onDelete}
            />
          ))}
        </div>
      ) : (
        <div className="text-center py-16 bg-slate-50 rounded-xl border border-slate-200 border-dashed">
          <Building2 size={48} className="mx-auto text-slate-400 mb-4" />
          <h3 className="text-lg font-medium text-slate-900 mb-1">No hay departamentos</h3>
          <p className="text-slate-500">No se encontraron propiedades que coincidan con los criterios.</p>
        </div>
      )}
    </div>
  );
};

// 3. Detail View
const DetailView = ({ apt, onBack, onEdit, onDelete }) => (
  <div className="animate-in slide-in-from-right-8 duration-300">
    <div className="mb-6">
      <button 
        onClick={onBack}
        className="inline-flex items-center text-sm font-medium text-slate-500 hover:text-slate-900 transition-colors"
      >
        <ChevronRight size={16} className="rotate-180 mr-1" />
        Volver al listado
      </button>
    </div>

    <div className="bg-white rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
      <div className="h-64 sm:h-80 lg:h-96 w-full relative">
        <img src={apt.image} alt={apt.title} className="w-full h-full object-cover" />
        <div className="absolute inset-0 bg-gradient-to-t from-black/60 to-transparent"></div>
        <div className="absolute bottom-6 left-6 right-6 flex justify-between items-end">
          <div>
            <div className="mb-3">
              <StatusBadge status={apt.status} />
            </div>
            <h1 className="text-3xl sm:text-4xl font-bold text-white mb-2">{apt.title}</h1>
            <p className="text-white/80 flex items-center text-lg">
              <MapPin size={18} className="mr-2" />
              {apt.address}, {apt.colonia}, {apt.city}
            </p>
          </div>
          <div className="hidden sm:block text-right">
            <p className="text-white/80 text-sm font-medium mb-1">Precio Mensual</p>
            <p className="text-3xl font-bold text-white">{formatPrice(apt.price)}</p>
          </div>
        </div>
      </div>

      <div className="p-6 sm:p-8">
        <div className="sm:hidden mb-8 pb-8 border-b border-slate-200">
          <p className="text-slate-500 text-sm font-medium mb-1">Precio Mensual</p>
          <p className="text-3xl font-bold text-blue-900">{formatPrice(apt.price)}</p>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          <div className="lg:col-span-2 space-y-8">
            <section>
              <h2 className="text-xl font-bold text-slate-900 mb-4">Descripción</h2>
              <p className="text-slate-600 leading-relaxed text-lg">
                {apt.description}
              </p>
            </section>

            <section>
              <h2 className="text-xl font-bold text-slate-900 mb-4">Características</h2>
              <div className="grid grid-cols-2 gap-4">
                <div className="bg-slate-50 p-4 rounded-xl flex items-center gap-4 border border-slate-100">
                  <div className="w-10 h-10 bg-white rounded-lg shadow-sm flex items-center justify-center text-blue-900">
                    <BedDouble size={20} />
                  </div>
                  <div>
                    <p className="text-sm text-slate-500 font-medium">Habitaciones</p>
                    <p className="text-lg font-bold text-slate-900">{apt.rooms}</p>
                  </div>
                </div>
                <div className="bg-slate-50 p-4 rounded-xl flex items-center gap-4 border border-slate-100">
                  <div className="w-10 h-10 bg-white rounded-lg shadow-sm flex items-center justify-center text-blue-900">
                    <Bath size={20} />
                  </div>
                  <div>
                    <p className="text-sm text-slate-500 font-medium">Baños</p>
                    <p className="text-lg font-bold text-slate-900">{apt.bathrooms}</p>
                  </div>
                </div>
              </div>
            </section>
          </div>

          <div>
            <div className="bg-slate-50 rounded-xl p-6 border border-slate-200 sticky top-24">
              <h3 className="text-lg font-bold text-slate-900 mb-4">Acciones de Administración</h3>
              <div className="space-y-3">
                <button 
                  onClick={() => onEdit(apt)}
                  className="w-full flex justify-center items-center gap-2 px-4 py-2.5 border border-slate-300 rounded-lg shadow-sm text-sm font-medium text-slate-700 bg-white hover:bg-slate-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-900 transition-colors"
                >
                  <Edit size={16} />
                  Editar Propiedad
                </button>
                <button 
                  onClick={() => onDelete(apt)}
                  className="w-full flex justify-center items-center gap-2 px-4 py-2.5 border border-transparent rounded-lg shadow-sm text-sm font-medium text-white bg-red-600 hover:bg-red-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-red-500 transition-colors"
                >
                  <Trash2 size={16} />
                  Eliminar Propiedad
                </button>
              </div>
              <div className="mt-6 pt-6 border-t border-slate-200">
                <p className="text-xs text-slate-500 text-center">ID de Referencia: #{apt.id.toString().padStart(4, '0')}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
);

// 4 & 5. Form View (Crear / Editar)
const FormView = ({ apt = null, onSave, onCancel }) => {
  const isEditing = !!apt;
  const [showError, setShowError] = useState(false); // Simulando validación para propósitos de UI

  return (
    <div className="animate-in fade-in duration-300 max-w-3xl mx-auto">
      <div className="mb-8">
        <h1 className="text-2xl font-bold text-slate-900">
          {isEditing ? 'Editar Departamento' : 'Nuevo Departamento'}
        </h1>
        <p className="mt-1 text-sm text-slate-500">
          {isEditing ? 'Modifica la información existente de esta propiedad.' : 'Completa el formulario para registrar una nueva propiedad en el sistema.'}
        </p>
      </div>

      <div className="bg-white rounded-xl shadow-sm border border-slate-200 overflow-hidden">
        <form className="p-6 sm:p-8 space-y-8" onSubmit={(e) => { e.preventDefault(); onSave(); }}>
          
          <div className="space-y-6">
            <h3 className="text-lg font-semibold text-slate-900 border-b border-slate-100 pb-2">Información Principal</h3>
            
            <div className="grid grid-cols-1 gap-6">
              <div>
                <label htmlFor="title" className="block text-sm font-medium text-slate-700 mb-1">Título de la publicación <span className="text-red-500">*</span></label>
                <input
                  type="text"
                  id="title"
                  defaultValue={apt?.title}
                  className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2.5 px-3 border"
                  placeholder="Ej. Hermoso departamento en Condesa"
                />
              </div>

              <div>
                <label htmlFor="description" className="block text-sm font-medium text-slate-700 mb-1">Descripción detallada</label>
                <textarea
                  id="description"
                  rows={4}
                  defaultValue={apt?.description}
                  className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2.5 px-3 border"
                  placeholder="Describe las amenidades, puntos de interés cercanos, etc."
                />
              </div>
            </div>
          </div>

          <div className="space-y-6">
            <h3 className="text-lg font-semibold text-slate-900 border-b border-slate-100 pb-2">Ubicación</h3>
            
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-6">
              <div className="sm:col-span-2">
                <label htmlFor="address" className="block text-sm font-medium text-slate-700 mb-1">Dirección exacta</label>
                <input
                  type="text"
                  id="address"
                  defaultValue={apt?.address}
                  className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2.5 px-3 border"
                />
              </div>
              <div>
                <label htmlFor="colonia" className="block text-sm font-medium text-slate-700 mb-1">Colonia</label>
                <input
                  type="text"
                  id="colonia"
                  defaultValue={apt?.colonia}
                  className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2.5 px-3 border"
                />
              </div>
              <div>
                <label htmlFor="city" className="block text-sm font-medium text-slate-700 mb-1">Ciudad</label>
                <input
                  type="text"
                  id="city"
                  defaultValue={apt?.city}
                  className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2.5 px-3 border"
                />
              </div>
            </div>
          </div>

          <div className="space-y-6">
            <h3 className="text-lg font-semibold text-slate-900 border-b border-slate-100 pb-2">Características y Precio</h3>
            
            <div className="grid grid-cols-1 sm:grid-cols-3 gap-6">
              <div>
                <label htmlFor="rooms" className="block text-sm font-medium text-slate-700 mb-1">Habitaciones <span className="text-red-500">*</span></label>
                <input
                  type="number"
                  id="rooms"
                  defaultValue={apt?.rooms}
                  min="0"
                  className={classNames(
                    "block w-full rounded-md shadow-sm sm:text-sm py-2.5 px-3 border",
                    showError ? "border-red-300 text-red-900 focus:ring-red-500 focus:border-red-500" : "border-slate-300 focus:ring-blue-900 focus:border-blue-900"
                  )}
                />
                {showError && <p className="mt-1 text-sm text-red-600">Este campo es requerido.</p>}
              </div>
              <div>
                <label htmlFor="bathrooms" className="block text-sm font-medium text-slate-700 mb-1">Baños</label>
                <input
                  type="number"
                  id="bathrooms"
                  defaultValue={apt?.bathrooms}
                  step="0.5"
                  min="0"
                  className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2.5 px-3 border"
                />
              </div>
              <div>
                <label htmlFor="price" className="block text-sm font-medium text-slate-700 mb-1">Precio Mensual ($) <span className="text-red-500">*</span></label>
                <input
                  type="number"
                  id="price"
                  defaultValue={apt?.price}
                  min="0"
                  className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2.5 px-3 border"
                />
              </div>
              <div className="sm:col-span-3">
                <label htmlFor="status" className="block text-sm font-medium text-slate-700 mb-1">Estado</label>
                <select
                  id="status"
                  defaultValue={apt?.status || 'Disponible'}
                  className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2.5 px-3 border bg-white"
                >
                  <option value="Disponible">Disponible</option>
                  <option value="Ocupado">Ocupado</option>
                  <option value="Mantenimiento">Mantenimiento</option>
                </select>
              </div>
            </div>
          </div>

          <div className="pt-6 border-t border-slate-200 flex flex-col-reverse sm:flex-row sm:justify-end gap-3">
            <button
              type="button"
              onClick={onCancel}
              className="w-full sm:w-auto px-6 py-2.5 border border-slate-300 shadow-sm text-sm font-medium rounded-lg text-slate-700 bg-white hover:bg-slate-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-900 transition-colors"
            >
              Cancelar
            </button>
            <button
              type="submit"
              className="w-full sm:w-auto px-6 py-2.5 border border-transparent shadow-sm text-sm font-medium rounded-lg text-white bg-blue-900 hover:bg-blue-800 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-900 transition-colors"
            >
              {isEditing ? 'Guardar Cambios' : 'Crear Departamento'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

// 6. Delete Confirmation
const DeleteConfirmation = ({ apt, onConfirm, onCancel }) => (
  <div className="animate-in fade-in duration-200 fixed inset-0 z-50 overflow-y-auto">
    <div className="flex items-end justify-center min-h-screen pt-4 px-4 pb-20 text-center sm:block sm:p-0">
      <div className="fixed inset-0 bg-slate-900/50 backdrop-blur-sm transition-opacity" onClick={onCancel} aria-hidden="true"></div>

      <span className="hidden sm:inline-block sm:align-middle sm:h-screen" aria-hidden="true">&#8203;</span>

      <div className="inline-block align-bottom bg-white rounded-xl text-left overflow-hidden shadow-xl transform transition-all sm:my-8 sm:align-middle sm:max-w-lg sm:w-full border border-slate-200">
        <div className="bg-white px-4 pt-5 pb-4 sm:p-6 sm:pb-4">
          <div className="sm:flex sm:items-start">
            <div className="mx-auto flex-shrink-0 flex items-center justify-center h-12 w-12 rounded-full bg-red-100 sm:mx-0 sm:h-10 sm:w-10">
              <AlertCircle className="h-6 w-6 text-red-600" aria-hidden="true" />
            </div>
            <div className="mt-3 text-center sm:mt-0 sm:ml-4 sm:text-left">
              <h3 className="text-lg leading-6 font-bold text-slate-900" id="modal-title">
                Eliminar Departamento
              </h3>
              <div className="mt-2 text-slate-500 text-sm">
                <p className="mb-4">
                  ¿Estás seguro que deseas eliminar esta propiedad? Esta acción no se puede deshacer y los datos se perderán permanentemente.
                </p>
                <div className="bg-slate-50 p-3 rounded-lg border border-slate-100">
                  <p className="font-semibold text-slate-900">{apt.title}</p>
                  <p className="text-slate-600">{apt.colonia}, {apt.city}</p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="bg-slate-50 px-4 py-3 sm:px-6 sm:flex sm:flex-row-reverse border-t border-slate-200">
          <button
            type="button"
            className="w-full inline-flex justify-center rounded-lg border border-transparent shadow-sm px-4 py-2 bg-red-600 text-base font-medium text-white hover:bg-red-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-red-500 sm:ml-3 sm:w-auto sm:text-sm transition-colors"
            onClick={onConfirm}
          >
            Sí, eliminar propiedad
          </button>
          <button
            type="button"
            className="mt-3 w-full inline-flex justify-center rounded-lg border border-slate-300 shadow-sm px-4 py-2 bg-white text-base font-medium text-slate-700 hover:bg-slate-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-900 sm:mt-0 sm:ml-3 sm:w-auto sm:text-sm transition-colors"
            onClick={onCancel}
          >
            Cancelar
          </button>
        </div>
      </div>
    </div>
  </div>
);

// 7. Search/Filter View
const SearchView = ({ onSearch, onCancel }) => (
  <div className="animate-in slide-in-from-top-4 duration-300 mb-8 bg-white p-6 rounded-xl shadow-sm border border-slate-200">
    <div className="flex justify-between items-center mb-6 border-b border-slate-100 pb-4">
      <h2 className="text-lg font-bold text-slate-900 flex items-center gap-2">
        <Search size={20} className="text-blue-900" />
        Filtros de Búsqueda
      </h2>
      <button onClick={onCancel} className="text-slate-400 hover:text-slate-600">
        <X size={20} />
      </button>
    </div>

    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4">
      <div>
        <label className="block text-sm font-medium text-slate-700 mb-1">Ciudad</label>
        <input type="text" className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2 px-3 border" placeholder="Ej. Ciudad de México" />
      </div>
      <div>
        <label className="block text-sm font-medium text-slate-700 mb-1">Colonia</label>
        <input type="text" className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2 px-3 border" placeholder="Ej. Polanco" />
      </div>
      <div>
        <label className="block text-sm font-medium text-slate-700 mb-1">Rango de Precio</label>
        <div className="flex items-center gap-2">
          <input type="number" placeholder="Mín" className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2 px-3 border" />
          <span className="text-slate-400">-</span>
          <input type="number" placeholder="Máx" className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2 px-3 border" />
        </div>
      </div>
      <div>
        <label className="block text-sm font-medium text-slate-700 mb-1">Estado</label>
        <select className="block w-full rounded-md border-slate-300 shadow-sm focus:border-blue-900 focus:ring-blue-900 sm:text-sm py-2 px-3 border bg-white">
          <option value="">Todos</option>
          <option value="Disponible">Disponible</option>
          <option value="Ocupado">Ocupado</option>
        </select>
      </div>
    </div>
    
    <div className="mt-6 flex justify-end gap-3">
      <button onClick={onCancel} className="px-4 py-2 border border-slate-300 shadow-sm text-sm font-medium rounded-md text-slate-700 bg-white hover:bg-slate-50 transition-colors">
        Limpiar
      </button>
      <button onClick={onSearch} className="px-6 py-2 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-blue-900 hover:bg-blue-800 transition-colors">
        Aplicar Filtros
      </button>
    </div>
  </div>
);

// 9. Error View
const ErrorView = ({ onHome }) => (
  <div className="min-h-[60vh] flex flex-col items-center justify-center text-center px-4 animate-in fade-in duration-500">
    <div className="w-24 h-24 bg-slate-100 rounded-full flex items-center justify-center text-slate-400 mb-6">
      <AlertCircle size={48} />
    </div>
    <h1 className="text-4xl font-bold text-slate-900 mb-3">Página no encontrada</h1>
    <p className="text-lg text-slate-500 max-w-md mx-auto mb-8">
      Lo sentimos, no pudimos encontrar la página que estás buscando. Puede que haya sido movida o eliminada.
    </p>
    <button 
      onClick={onHome}
      className="inline-flex items-center gap-2 px-6 py-3 border border-transparent text-base font-medium rounded-lg shadow-sm text-white bg-blue-900 hover:bg-blue-800 transition-colors"
    >
      <Home size={18} />
      Volver al Inicio
    </button>
  </div>
);

// MAIN APP COMPONENT
export default function App() {
  const [activeTab, setActiveTab] = useState('home');
  const [selectedApt, setSelectedApt] = useState(null);
  const [aptToDelete, setAptToDelete] = useState(null);
  const [showSearch, setShowSearch] = useState(false);

  // Navigation handlers
  const handleView = (apt) => {
    setSelectedApt(apt);
    setActiveTab('detail');
    window.scrollTo(0, 0);
  };

  const handleEdit = (apt) => {
    setSelectedApt(apt);
    setActiveTab('edit');
    window.scrollTo(0, 0);
  };

  const handleDelete = (apt) => {
    setAptToDelete(apt);
  };

  const confirmDelete = () => {
    // Aquí iría la lógica real de borrado
    setAptToDelete(null);
    if (activeTab === 'detail') setActiveTab('list');
  };

  const handleSave = () => {
    // Simular guardado y volver
    setActiveTab('list');
  };

  const handleCancelForm = () => {
    if (activeTab === 'edit' && selectedApt) {
      setActiveTab('detail');
    } else {
      setActiveTab('list');
    }
  };

  // Render main content based on state
  const renderContent = () => {
    switch (activeTab) {
      case 'home':
        return <HomeView setActiveTab={setActiveTab} />;
      
      case 'list':
        return (
          <>
            {showSearch && <SearchView onSearch={() => setShowSearch(false)} onCancel={() => setShowSearch(false)} />}
            <ListView 
              onView={handleView} 
              onEdit={handleEdit} 
              onDelete={handleDelete}
              onSearch={() => setShowSearch(!showSearch)}
            />
          </>
        );
      
      case 'available':
        return (
          <ListView 
            title="Departamentos Disponibles" 
            subtitle="Propiedades listas para ser rentadas inmediatamente."
            filterFn={(apt) => apt.status === 'Disponible'}
            onView={handleView} 
            onEdit={handleEdit} 
            onDelete={handleDelete}
          />
        );
        
      case 'search':
        return (
          <>
            <SearchView onSearch={() => {}} onCancel={() => setActiveTab('list')} />
            <ListView 
              title="Resultados de búsqueda" 
              subtitle="Mostrando todos los departamentos."
              onView={handleView} 
              onEdit={handleEdit} 
              onDelete={handleDelete}
            />
          </>
        );
      
      case 'detail':
        return selectedApt ? (
          <DetailView 
            apt={selectedApt} 
            onBack={() => setActiveTab('list')} 
            onEdit={handleEdit}
            onDelete={handleDelete}
          />
        ) : <ErrorView onHome={() => setActiveTab('home')} />;
      
      case 'create':
        return <FormView onSave={handleSave} onCancel={handleCancelForm} />;
      
      case 'edit':
        return selectedApt ? (
          <FormView apt={selectedApt} onSave={handleSave} onCancel={handleCancelForm} />
        ) : <ErrorView onHome={() => setActiveTab('home')} />;
        
      case 'error':
        return <ErrorView onHome={() => setActiveTab('home')} />;
        
      default:
        return <HomeView setActiveTab={setActiveTab} />;
    }
  };

  return (
    <div className="min-h-screen flex flex-col bg-slate-50 font-sans text-slate-900">
      <Navbar activeTab={activeTab} setActiveTab={setActiveTab} />
      
      <main className="flex-1 max-w-7xl w-full mx-auto px-4 sm:px-6 lg:px-8 py-8">
        {renderContent()}
      </main>

      <Footer />

      {/* Modals */}
      {aptToDelete && (
        <DeleteConfirmation 
          apt={aptToDelete} 
          onConfirm={confirmDelete} 
          onCancel={() => setAptToDelete(null)} 
        />
      )}
    </div>
  );
}
